using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class CategoriesProducts
    {
        public int? CategoriesId { get; set; }
        public int? ProductsId { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual Products Products { get; set; }
    }
}
