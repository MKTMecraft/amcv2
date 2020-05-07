using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractMasterLocations
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public int StateId { get; set; }
        public int ServiceTypeId { get; set; }
        public int BarTypeId { get; set; }
        public string StateName { get; set; }
        public string MasterServiceTypeName { get; set; }
        public string MasterBarTypeName { get; set; }
        public bool IsChecked { get; set; }
        //[NotMapped]
        //public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("mm/dd/yyyy") : "-";
        //[NotMapped]
        //public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("mm/dd/yyyy") : "-";

    }
}
