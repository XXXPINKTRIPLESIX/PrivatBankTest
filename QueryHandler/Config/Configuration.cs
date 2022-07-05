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
        public static string ConnectionString { get; set; } = "Server=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=PrivatBankDb;";
    }
}
