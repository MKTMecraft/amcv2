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
    public class MasterServicesTypesServices : AbstractMasterServicesTypesService
    {
        private AbstractMasterServicesTypesDao abstractMasterServicesTypesDao;

        public MasterServicesTypesServices(AbstractMasterServicesTypesDao abstractMasterServicesTypesDao)
        {
            this.abstractMasterServicesTypesDao = abstractMasterServicesTypesDao;
        }

        public override SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes_Upsert(AbstractMasterServicesTypes AbstractMasterServicesTypes)
        {
            return abstractMasterServicesTypesDao.MasterServicesType_Upsert(AbstractMasterServicesTypes);
        }

        public override SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes_Id(int Id)
        {
            return abstractMasterServicesTypesDao.MasterServicesType_Id(Id);
        }

        public override PagedList<AbstractMasterServicesTypes> MasterServicesTypes_All(PageParam pageParam, string search, AbstractMasterServicesTypes AbstractMasterServicesTypes = null)
        {
            return abstractMasterServicesTypesDao.MasterServicesType_All(pageParam,search, AbstractMasterServicesTypes);
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
