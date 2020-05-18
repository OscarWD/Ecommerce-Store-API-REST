using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceStoreAPI.Data.Contexts;
using EcommerceStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStoreAPI.Data.Contracts
{
    public class SubCategorieRepository : ISubCategorieRepository
    {
        private readonly EcommerceContext _context;

        public SubCategorieRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void CreateSubCategorie(SubCategorie subCategorie)
        {
            if (subCategorie == null)
                throw new ArgumentNullException(nameof(subCategorie));

            _context.Add(subCategorie);
        }

        public void DeleteSubCategorie(SubCategorie subCategorie)
        {
            if (subCategorie == null)
                throw new ArgumentNullException(nameof(subCategorie));

            _context.Remove(subCategorie);
        }

        public SubCategorie GetSubCategorieById(int id)
        {
            return _context.SubCategorie.FirstOrDefault(predicate => predicate.Id == id);
        }

        public IEnumerable<SubCategorie> GetSubCategories()
        {
            return _context.SubCategorie.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSubCategorie(SubCategorie subCategorie)
        {
            if (subCategorie == null)
                throw new ArgumentNullException(nameof(subCategorie));

            _context.Entry(subCategorie).State = EntityState.Modified;

        }
    }
}