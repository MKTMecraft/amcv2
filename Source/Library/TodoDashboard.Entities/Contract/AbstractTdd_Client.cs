using TodoDashboard.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractTdd_Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public string IdStr { get; set; }

        [NotMapped]
        public string DobStr => DOB == null ? "-" : DOB.ToString("dd-MM-yyyy");

        [NotMapped]
        public string LastLoginStr => LastLogin == null ? "-" : LastLogin.ToString("dd MMM yyyy hh:mm tt");

        [NotMapped]
        public string CreatedDateStr => CreatedDate == null ? "-" : CreatedDate.ToString("dd MMM yyyy hh:mm tt");

        [NotMapped]
        public string UpdatedDateStr => UpdatedDate == null ? "-" : UpdatedDate.ToString("dd MMM yyyy hh:mm tt");
    }
}
