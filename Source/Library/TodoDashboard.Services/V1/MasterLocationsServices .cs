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
    public class MasterLocationsServices : AbstractMasterLocationsService
    {
        private AbstractMasterLocationsDao abstractMasterLocationsDao;

        public MasterLocationsServices(AbstractMasterLocationsDao abstractMasterLocationsDao)
        {
            this.abstractMasterLocationsDao = abstractMasterLocationsDao;
        }

        public override SuccessResult<AbstractMasterLocations> MasterLocations_Upsert(AbstractMasterLocations AbstractMasterLocations)
        {
            return abstractMasterLocationsDao.MasterLocations_Upsert(AbstractMasterLocations);
        }

        public override SuccessResult<AbstractMasterLocations> MasterLocations_Id(int Id)
        {
            return abstractMasterLocationsDao.MasterLocations_Id(Id);
        }

        public override PagedList<AbstractMasterLocations> MasterLocations_All(PageParam pageParam, string search, AbstractMasterLocations AbstractMasterLocations = null, int WineId = 0)
        {
            return abstractMasterLocationsDao.MasterLocations_All(pageParam,search, AbstractMasterLocations,  WineId);
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
