using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Entityframeworktest.Models
{
    public class UserMaster
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public string UserInRole { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int IsActive { get; set; }

    }
}

