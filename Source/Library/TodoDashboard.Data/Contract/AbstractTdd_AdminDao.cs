using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;

namespace TodoDashboard.Data.Contract
{
   public abstract class AbstractTdd_AdminDao : AbstractBaseDao
    {
        public abstract bool Tdd_Admin_LastLogin(int Id);
        public abstract bool Tdd_Admin_ChangePassword(int Id,string Password);
        public abstract SuccessResult<AbstractTdd_Admin> Tdd_Admin_Login(string Email, string Password);
        public abstract SuccessResult<AbstractTdd_Admin> TddAdmin_ById(int Id);
    }
}
