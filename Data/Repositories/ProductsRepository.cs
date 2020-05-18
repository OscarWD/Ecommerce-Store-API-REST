using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceStoreAPI.Data.Contexts;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStoreAPI.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly EcommerceContext _context;
        public ProductsRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void CreateProduct(Products product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _context.Products.Add(product);
        }

        public void DeleteProduct(Products product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            _context.Products.Remove(product);
        }

        public Products GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(predicate => predicate.Id == id);
        }

        public IEnumerable<Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
    }
}