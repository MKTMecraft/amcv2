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
    public class UsersServices : AbstractUsersServices
    {
        private AbstractUsersDao abstractUsersDao;

        public UsersServices (AbstractUsersDao abstractUsersDao)
        {
            this.abstractUsersDao = abstractUsersDao;
        }

        public override SuccessResult<AbstractUsers> Login(AbstractUsers abstractUsers)
        {
            return this.abstractUsersDao.Login(abstractUsers);
        }

        public override SuccessResult<AbstractUsers> VerifyEmail(string email)
        {
            return this.abstractUsersDao.VerifyEmail(email);
        }

        public override int UserPasswordUpdate(AbstractUsers abstractUsers)
        {
            return this.abstractUsersDao.UserPasswordUpdate(abstractUsers);
        }

        public override PagedList<AbstractUsers> SelectAll(PageParam pageParam, string search)
        {
            return this.abstractUsersDao.SelectAll(pageParam, search);
        }

        public override SuccessResult<AbstractUsers> Select(int id)
        {
            return this.abstractUsersDao.Select(id);
        }

        public override SuccessResult<AbstractUsers> InsertUpdateUsers(AbstractUsers abstractusers)
        {
            SuccessResult<AbstractUsers> result = this.abstractUsersDao.InsertUpdateUsers(abstractusers);
            return result;
        }

        public override bool Delete(int id)
        {
            return this.abstractUsersDao.Delete(id);
        }

        public override PagedList<AbstractUsers> MenuSelectAll()
        {
            return this.abstractUsersDao.MenuSelectAll();
        }

        public override bool UsersStatusChange(int id)
        {
            return this.abstractUsersDao.UsersStatusChange(id);
        }

    }
}
