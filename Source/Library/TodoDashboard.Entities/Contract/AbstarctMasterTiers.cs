using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractMasterTiers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //[NotMapped]
        //public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("mm/dd/yyyy") : "-";
        //[NotMapped]
        //public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("mm/dd/yyyy") : "-";

    }
}
