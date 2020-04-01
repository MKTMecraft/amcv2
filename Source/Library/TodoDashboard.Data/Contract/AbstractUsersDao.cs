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
   public abstract class AbstractUsersDao : AbstractBaseDao
    {
        public abstract SuccessResult<AbstractUsers> Login(AbstractUsers abstractUsers);

        public abstract SuccessResult<AbstractUsers> VerifyEmail(string email);        

        public abstract PagedList<AbstractUsers> SelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractUsers> Select(int id);

        public abstract SuccessResult<AbstractUsers> InsertUpdateUsers(AbstractUsers abstractusers);

        public abstract bool Delete(int id);

        public abstract int UserPasswordUpdate(AbstractUsers abstractUsers);

        public abstract PagedList<AbstractUsers> MenuSelectAll();

        public abstract bool UsersStatusChange(int id);

    }
}
