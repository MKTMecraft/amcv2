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
    public class MasterBarTypesServices : AbstractMasterBarTypesService
    {
        private AbstractMasterBarTypesDao abstractMasterBarTypesDao;

        public MasterBarTypesServices(AbstractMasterBarTypesDao abstractMasterBarTypesDao)
        {
            this.abstractMasterBarTypesDao = abstractMasterBarTypesDao;
        }

        public override SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Upsert(AbstractMasterBarTypes AbstractMasterBarTypes)
        {
            return abstractMasterBarTypesDao.MasterBarTypes_Upsert(AbstractMasterBarTypes);
        }

        public override SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Id(int Id)
        {
            return abstractMasterBarTypesDao.MasterBarTypes_Id(Id);
        }

        public override PagedList<AbstractMasterBarTypes> MasterBarTypes_All(PageParam pageParam, string search, AbstractMasterBarTypes AbstractMasterBarTypes = null)
        {
            return abstractMasterBarTypesDao.MasterBarTypes_All(pageParam,search, AbstractMasterBarTypes);
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
