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
    public class MasterTiersServices : AbstractMasterTiersService
    {
        private AbstractMasterTiersDao abstractMasterTiersDao;

        public MasterTiersServices(AbstractMasterTiersDao abstractMasterTiersDao)
        {
            this.abstractMasterTiersDao = abstractMasterTiersDao;
        }

        public override SuccessResult<AbstractMasterTiers> MasterTiers_Upsert(AbstractMasterTiers AbstractMasterTiers)
        {
            return abstractMasterTiersDao.MasterTiers_Upsert(AbstractMasterTiers);
        }

        public override SuccessResult<AbstractMasterTiers> MasterTiers_Id(int Id)
        {
            return abstractMasterTiersDao.MasterTiers_Id(Id);
        }

        public override PagedList<AbstractMasterTiers> MasterTiers_All(PageParam pageParam, string search, AbstractMasterTiers AbstractMasterTiers = null)
        {
            return abstractMasterTiersDao.MasterTiers_All(pageParam,search, AbstractMasterTiers);
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
