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
    public class MasterWinesServices : AbstractMasterWinesService
    {
        private AbstractMasterWinesDao abstractMasterWinesDao;

        public MasterWinesServices(AbstractMasterWinesDao abstractMasterWinesDao)
        {
            this.abstractMasterWinesDao = abstractMasterWinesDao;
        }

        public override SuccessResult<AbstractMasterWines> MasterWines_Upsert(AbstractMasterWines AbstractMasterWines)
        {
            return abstractMasterWinesDao.MasterWines_Upsert(AbstractMasterWines);
        }

        public override SuccessResult<AbstractMasterWines> MasterWines_Id(int Id)
        {
            return abstractMasterWinesDao.MasterWines_Id(Id);
        }

        public override PagedList<AbstractMasterWines> MasterWines_All(PageParam pageParam, string search, AbstractMasterWines AbstractMasterWines = null,int LocationId = 0)
        {
            return abstractMasterWinesDao.MasterWines_All(pageParam,search, AbstractMasterWines, LocationId);
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
