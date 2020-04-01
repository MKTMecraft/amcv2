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
    public abstract class AbstractUsers : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Gender { get; set; }
        public string Dob { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UserType { get; set; }
        public string Lastlogin { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string AvtarPhotoCopy { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string DeviceToken { get; set; }
        public string ImeiNumber { get; set; }
    }
}
