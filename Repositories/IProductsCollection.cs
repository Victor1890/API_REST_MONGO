using API_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repositories
{
    public interface IProductsCollection
    {
        Task InsertProducts(Products products);
        Task UpdateProducts(Products products);
        Task DeleteProducts(string id);

        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductsById(string id);
    }
}
