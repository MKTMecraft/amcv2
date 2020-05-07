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
    public class MasterWineVaritalsServices : AbstractMasterWineVaritalsService
    {
        private AbstractMasterWineVaritalsDao abstractMasterWineVaritalsDao;

        public MasterWineVaritalsServices(AbstractMasterWineVaritalsDao abstractMasterWineVaritalsDao)
        {
            this.abstractMasterWineVaritalsDao = abstractMasterWineVaritalsDao;
        }

        public override SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Upsert(AbstractMasterWineVaritals AbstractMasterWineVaritals)
        {
            return abstractMasterWineVaritalsDao.MasterWineVaritals_Upsert(AbstractMasterWineVaritals);
        }

        public override SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Id(int Id)
        {
            return abstractMasterWineVaritalsDao.MasterWineVaritals_Id(Id);
        }

        public override PagedList<AbstractMasterWineVaritals> MasterWineVaritals_All(PageParam pageParam, string search, AbstractMasterWineVaritals AbstractMasterWineVaritals = null)
        {
            return abstractMasterWineVaritalsDao.MasterWineVaritals_All(pageParam,search, AbstractMasterWineVaritals);
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
