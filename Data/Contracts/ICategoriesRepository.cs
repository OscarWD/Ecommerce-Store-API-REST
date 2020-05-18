using System.Collections.Generic;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data.Contracts
{
    public interface ICategoriesRepository
    {
        IEnumerable<Categories> GetCategories();
        Categories GetCategorieById(int id);
        void CreateCategorie(Categories categorie);
        void UpdateCategorie(Categories categorie);
        void DeleteCategorie(Categories categorie);
        bool SaveChanges();
    }
}