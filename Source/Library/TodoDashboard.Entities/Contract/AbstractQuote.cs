using TodoDashboard.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDashboard.Entities.Contract
{
    public abstract class AbstractQuote : BaseModel
    {
        public int Id { get; set; }
        public int ServiceType { get; set; }
        public string PostalCode { get; set; }
        public string PropertyLayout { get; set; }
        public int Floor { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public string Extras { get; set; }
        public string PropertyCondition { get; set; }
        public int CleaningType { get; set; }
        public int CleaningPrefDay { get; set; }
        public string PropertyAddress { get; set; }
        public string ApplyCodes { get; set; }
        public string ServiceDate { get; set; }
        public string ServiceTime { get; set; }
        public string FlexibleDateTime { get; set; }
        public string GainAccess { get; set; }
        public string GainAccessDescription { get; set; }
        public string Park { get; set; }
        public string AdditionalInformation { get; set; }
        public string UploadDoc { get; set; }
        public string Tip { get; set; }
    }
}
