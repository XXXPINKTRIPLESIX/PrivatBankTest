using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace QueryHandler.Config
{
    static public class Configuration
    {
        public static string ConnectionString { get; set; } = @"Data Source=DESKTOP-RC7MDO3;Initial Catalog=PrivatBankDb;
                                                                Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                                TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                                                MultiSubnetFailover=False";
    }
}
