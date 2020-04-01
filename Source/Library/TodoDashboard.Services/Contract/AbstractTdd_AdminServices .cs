using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;

namespace TodoDashboard.Services.Contract
{
    public abstract class AbstractTdd_AdminServices : AbstractBaseService
    {
        public abstract bool Tdd_Admin_LastLogin(string Id);
        public abstract bool Tdd_Admin_ChangePassword(string Id, string Password);
        public abstract SuccessResult<AbstractTdd_Admin> Tdd_Admin_Login(string Email, string Password);
        public abstract SuccessResult<AbstractTdd_Admin> TddAdmin_ById(string Id);

    }
}
