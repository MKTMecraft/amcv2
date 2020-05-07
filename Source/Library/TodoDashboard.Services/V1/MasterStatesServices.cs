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
    public class MasterStatesServices : AbstractMasterStatesService
    {
        private AbstractMasterStatesDao abstractMasterStatesDao;

        public MasterStatesServices(AbstractMasterStatesDao abstractMasterStatesDao)
        {
            this.abstractMasterStatesDao = abstractMasterStatesDao;
        }

        public override PagedList<AbstractMasterStates> MasterStates_All(PageParam pageParam, string search, AbstractMasterStates AbstractMasterStates = null)
        {
            return abstractMasterStatesDao.MasterStates_All(pageParam,search, AbstractMasterStates);
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
