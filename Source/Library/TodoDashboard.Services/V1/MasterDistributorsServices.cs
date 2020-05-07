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
    public class MasterDistributorsServices : AbstractMasterDistributorsService
    {
        private AbstractMasterDistributorsDao abstractMasterDistributorsDao;

        public MasterDistributorsServices(AbstractMasterDistributorsDao abstractMasterDistributorsDao)
        {
            this.abstractMasterDistributorsDao = abstractMasterDistributorsDao;
        }

        public override SuccessResult<AbstractMasterDistributors> MasterDistributors_Upsert(AbstractMasterDistributors AbstractMasterDistributors)
        {
            return abstractMasterDistributorsDao.MasterDistributors_Upsert(AbstractMasterDistributors);
        }

        public override SuccessResult<AbstractMasterDistributors> MasterDistributors_Id(int Id)
        {
            return abstractMasterDistributorsDao.MasterDistributors_Id(Id);
        }

        public override PagedList<AbstractMasterDistributors> MasterDistributors_All(PageParam pageParam, string search, AbstractMasterDistributors AbstractMasterDistributors = null)
        {
            return abstractMasterDistributorsDao.MasterDistributors_All(pageParam,search, AbstractMasterDistributors);
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
