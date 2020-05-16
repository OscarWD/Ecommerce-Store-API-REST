using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceStoreAPI.Data.Contexts;
using EcommerceStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStoreAPI.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly EcommerceContext _context;

        public CategoriesRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void CreateCategorie(Categories categorie)
        {
            if (categorie == null)
                throw new ArgumentNullException(nameof(categorie));
            _context.Categories.Add(categorie);
        }

        public void DeleteCategorie(Categories categorie)
        {
            if (categorie == null)
                throw new ArgumentNullException(nameof(categorie));
            _context.Categories.Remove(categorie);
        }

        public Categories GetCategorieById(int id)
        {
            return _context.Categories.FirstOrDefault(predicate => predicate.Id == id);
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

        public void UpdateCategorie(Categories categorie)
        {
            _context.Entry(categorie).State = EntityState.Modified;
        }
    }
}