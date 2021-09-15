using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Entityframeworktest.Models
{
    public class UserMaster
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime EmployeeDob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}

