using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_REST.Repositories
{
    public class ProductsCollection : IProductsCollection
    {
        internal MongoDB_Repository _repository = new MongoDB_Repository();
        private IMongoCollection<Products> Collection;

        public ProductsCollection()
        {
            Collection = _repository.database.GetCollection<Products>("Products");
        }

        public async Task DeleteProducts(string id)
        {
            var filter = Builders<Products>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync(); 
        }

        public async Task<Products> GetProductsById(string id)
        {
            return await Collection.FindAsync(
                    new BsonDocument { { "_id", new ObjectId(id) } }
                ).Result.FirstAsync();
        }

        public async Task InsertProducts(Products products)
        {
            await Collection.InsertOneAsync(products);
        }

        public async Task UpdateProducts(Products products)
        {
            var filter = Builders<Products>
                .Filter
                .Eq(s => s.Id, products.Id);
            await Collection.ReplaceOneAsync(filter, products);
        }
    }
}
