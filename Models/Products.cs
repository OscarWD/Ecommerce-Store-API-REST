using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quantity { get; set; }
        public int SubCategorieId { get; set; }

        public virtual SubCategorie SubCategorie { get; set; }
    }
}
