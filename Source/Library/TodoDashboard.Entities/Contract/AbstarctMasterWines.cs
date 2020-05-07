using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractMasterWines
    {
        public int Id { get; set; }
        public string WineName { get; set; }
        public int MasterVarietalId { get; set; }
        public string Calories { get; set; }
        public int MasterDistributorId { get; set; }
        public int TierId { get; set; }
        public string MasterDistributorName { get; set; }
        public string MasterVarietalName { get; set; }
        public string TierName { get; set; }
        public bool IsChecked { get; set; }

        //[NotMapped]
        //public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("mm/dd/yyyy") : "-";
        //[NotMapped]
        //public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("mm/dd/yyyy") : "-";

    }
}
