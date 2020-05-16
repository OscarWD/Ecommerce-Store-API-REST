using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class Bills
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int? UsersId { get; set; }

        public virtual Users Users { get; set; }
    }
}
