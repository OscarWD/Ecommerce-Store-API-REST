using System.Collections.Generic;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data.Contracts
{
    public interface ISubCategorieRepository
    {
        IEnumerable<SubCategorie> GetSubCategories();
        SubCategorie GetSubCategorieById(int id);
        void CreateSubCategorie(SubCategorie subCategorie);
        void UpdateSubCategorie(SubCategorie subCategorie);
        void DeleteSubCategorie(SubCategorie subCategorie);
        bool SaveChanges();
    }
}