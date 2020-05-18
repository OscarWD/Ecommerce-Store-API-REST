using System.Collections.Generic;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data.Contracts
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetProducts();
        Products GetProductById(int id);
        void CreateProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(Products product);
        bool SaveChanges();
    }
}