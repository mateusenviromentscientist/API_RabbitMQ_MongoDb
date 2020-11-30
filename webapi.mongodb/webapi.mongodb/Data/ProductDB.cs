using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.mongodb.Data.Configuration;
using webapi.mongodb.Entities;

namespace webapi.mongodb.Data
{
    public class Productdb
    {
        private readonly IMongoCollection<Products> _productCollection;
      
        public Productdb(IProductStoreDatabaseSettings settings)
        {
            var mdcClient = new MongoClient(settings.ConnectionString);
            var database = mdcClient.GetDatabase(settings.DatabaseName);

            _productCollection = database.GetCollection<Products>(settings.ClientesCollectionName);

        }

        internal object Get()
        {
            throw new NotImplementedException();
        }

        public List<Products> Get(Productdb _productdb)
        {
            return _productCollection.Find(book => true).ToList();
        }

        public Products GetById(string id)
        {
            return _productCollection.Find<Products>(products => products.Id == id).FirstOrDefault();
        }

        public Products Create(Products book)
        {
            _productCollection.InsertOne(book);
            return book;
        }
        
        public void Update(string id, Products products)
        {
            _productCollection.ReplaceOne(products => products.Id == id, products);
        }
        public void Delete(Products products)
        {
            _productCollection.DeleteOne(products => products.Id == products.Id);
        }
        public void DeleteById(string Id)
        {
            _productCollection.DeleteOne(products => products.Id == Id);
        }
    }
}
