using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractMasterUser
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public int LoginType { get; set; }
        
        //[NotMapped]
        //public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("mm/dd/yyyy") : "-";
        //[NotMapped]
        //public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("mm/dd/yyyy") : "-";

    }
}
