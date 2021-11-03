﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Serilog;
using QueryHandler.Logging;
using System.Data.SqlClient;
using QueryHandler.Messages;
using System.Collections.Generic;
using QueryHandler.Interfaces;
using QueryHandler.DTO;

namespace QueryHandler
{
    class Program
    {
        private static ILogger _logger;
        private static IConnection _connection;

        static Program()
        {
            _logger = Logger.Create();
        }

        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();

            var channel1 = CreateChannel("rpc_queue");
            var channel2 = CreateChannel("rpc_2_queue");
            var channel3 = CreateChannel("rpc_3_queue");


            var consumer1 = new EventingBasicConsumer(channel1);
            channel1.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer1);
            consumer1.Received += async (model, ea) => await RequestHandler<RequestMessage, int>(ea, channel1);


            var consumer2 = new EventingBasicConsumer(channel2);
            channel2.BasicConsume(queue: "rpc_2_queue", autoAck: false, consumer: consumer2);
            consumer2.Received += async (model, ea) => await RequestHandler<RequestByIdMessage, ByIdResponseDTO>(ea, channel2);

            
            var consumer3 = new EventingBasicConsumer(channel3);
            channel3.BasicConsume(queue: "rpc_3_queue", autoAck: false, consumer: consumer3);
            consumer3.Received += async (model, ea) => await RequestHandler<RequestsMessage, IEnumerable<RequestsResponseDTO>>(ea, channel3);

            Console.WriteLine(" Press [enter] to exit.");
            if (Console.Read() == 13)
            {
                DisposeChannel(channel1);
                DisposeChannel(channel2);
                DisposeChannel(channel3);

                if (_connection != null)
                    _connection.Dispose();
            }
        }

        public static async Task RequestHandler<T, U>(BasicDeliverEventArgs ea, IModel channel)
        {
            string response = null;

            var body = ea.Body.ToArray();
            var props = ea.BasicProperties;
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            try
            {
                var message = Encoding.UTF8.GetString(body);

                IMessage<U> request = JsonConvert.DeserializeObject<T>(message) as IMessage<U>;

                _logger.ForContext("log", "MESSAGE")
                .Information("{message}", message);

                var result = await request.ExecRequestAsync();

                response = JsonConvert.SerializeObject(result);
            }
            catch(JsonException jsonException) 
            {
                _logger.Error(jsonException.Message);
                response = "";
            }
            catch (InvalidCastException castException) 
            {
                _logger.Error(castException.Message);
                response = "";
            }
            catch (SqlException sqlException)
            {
                _logger.Error(sqlException.Message);
                response = "";
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                response = "";
            }
            finally
            {
                var responseBytes = Encoding.UTF8.GetBytes(response);
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        }

        private static IModel CreateChannel(string queueName)
        {
            var channel = _connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicQos(0, 1, false);

            return channel;
        }

        private static void DisposeChannel(IModel channel)
        {
            if (channel != null)
                channel.Dispose();
        }
    }
}