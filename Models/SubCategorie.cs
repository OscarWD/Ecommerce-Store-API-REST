using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class SubCategorie
    {
        public SubCategorie()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoriesId { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
