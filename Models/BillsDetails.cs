using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class BillsDetails
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int? BillsId { get; set; }
        public int? ProductsId { get; set; }

        public virtual Bills Bills { get; set; }
        public virtual Products Products { get; set; }
    }
}
