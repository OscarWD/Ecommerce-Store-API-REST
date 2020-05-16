using System.Collections.Generic;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data
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