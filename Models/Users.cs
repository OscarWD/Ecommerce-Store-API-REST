using System;
using System.Collections.Generic;

namespace EcommerceStoreAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Bills = new HashSet<Bills>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int City { get; set; }
        public string Adress { get; set; }
        public string AvatarUrl { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
    }
}
