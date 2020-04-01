using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Data.Contract;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Services.Contract;

namespace TodoDashboard.Services.V1
{
    public class Tdd_AdminServices : AbstractTdd_AdminServices
    {
        private AbstractTdd_AdminDao abstractTdd_AdminDao;

        public Tdd_AdminServices(AbstractTdd_AdminDao abstractTdd_AdminDao)
        {
            this.abstractTdd_AdminDao = abstractTdd_AdminDao;
        }

        public override bool Tdd_Admin_LastLogin(string Id)
        {
            bool result = false;
            result = abstractTdd_AdminDao.Tdd_Admin_LastLogin(ConvertTo.Integer(ConvertTo.Base64Decode(Id)));
            return result;
        }

        public override bool Tdd_Admin_ChangePassword(string Id, string Password)
        {
            bool result = false;
            result = abstractTdd_AdminDao.Tdd_Admin_ChangePassword(ConvertTo.Integer(ConvertTo.Base64Decode(Id)),Password);
            return result;
        }

        public override SuccessResult<AbstractTdd_Admin> Tdd_Admin_Login(string Email, string Password)
        {
            return abstractTdd_AdminDao.Tdd_Admin_Login(Email,Password);
        }

        public override SuccessResult<AbstractTdd_Admin> TddAdmin_ById(string Id)
        {
            return abstractTdd_AdminDao.TddAdmin_ById(ConvertTo.Integer(ConvertTo.Base64Decode(Id)));
        }
    }
}
