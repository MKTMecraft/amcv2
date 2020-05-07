using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Data.Contract;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;
using TodoDashboard.Services.Contract;

namespace TodoDashboard.Services.V1
{
    public class MasterUserServices : AbstractMasterUserService
    {
        private AbstractMasterUserDao abstractMasterUserDao;

        public MasterUserServices(AbstractMasterUserDao abstractMasterUserDao)
        {
            this.abstractMasterUserDao = abstractMasterUserDao;
        }

        public override SuccessResult<AbstractMasterUser> MasterUser_Upsert(AbstractMasterUser AbstractMasterUser)
        {
            return abstractMasterUserDao.MasterUser_Upsert(AbstractMasterUser);
        }

        public override SuccessResult<AbstractMasterUser> MasterUser_Id(int Id)
        {
            return abstractMasterUserDao.MasterUser_Id(Id);
        }

        public override PagedList<AbstractMasterUser> MasterUser_All(PageParam pageParam, string search, AbstractMasterUser AbstractMasterUser = null)
        {
            return abstractMasterUserDao.MasterUser_All(pageParam,search, AbstractMasterUser);
        }

        public override SuccessResult<AbstractMasterUser> MasterUser_Login(AbstractMasterUser abstractMasterUser)
        {
            return abstractMasterUserDao.MasterUser_Login(abstractMasterUser);
        }
        
        public override bool MasterUser_ChangePassword(MasterUser masterUser)
        {
            return abstractMasterUserDao.MasterUser_ChangePassword(masterUser);
        }

        //public override PagedList<AbstractAddress> SelectAll(PageParam pageParam)
        //{
        //    return this.abstractAddressDao.SelectAll(pageParam);
        //}
        //public override SuccessResult<AbstractAddress> Select(int id)
        //{
        //    return this.abstractAddressDao.Select(id);
        //}
        //public override SuccessResult<AbstractAddress> InsertUpdateAddress(AbstractAddress abstractAddress)
        //{
        //    SuccessResult<AbstractAddress> result = this.abstractAddressDao.InsertUpdateAddress(abstractAddress);
        //    return result;
        //}
        //public override bool Delete(int id)
        //{
        //    return this.abstractAddressDao.Delete(id);
        //}

        //public override PagedList<AbstractAddress> GetAddressByCustId(int CustId)
        //{
        //    return this.abstractAddressDao.GetAddressByCustId(CustId);
        //}
    }
}
