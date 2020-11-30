using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace webapi.mongodb.Data.Configuration
{
    public class ProductStoreDatabaseSettings : IProductStoreDatabaseSettings
    {
        public string ClientesCollectionName { get; set;}
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductStoreDatabaseSettings
    {
        string ClientesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
