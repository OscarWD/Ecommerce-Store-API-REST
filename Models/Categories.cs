using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class Categories
    {
        public Categories()
        {
            SubCategorie = new HashSet<SubCategorie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SubCategorie> SubCategorie { get; set; }
    }
}
