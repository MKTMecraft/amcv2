using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;

namespace TodoDashboard.Data.Contract
{
    public abstract class AbstractMasterLocationsDao
    {
        public abstract SuccessResult<AbstractMasterLocations> MasterLocations_Upsert(AbstractMasterLocations AbstractMasterLocations);

        public abstract SuccessResult<AbstractMasterLocations> MasterLocations_Id(int Id);

        public abstract PagedList<AbstractMasterLocations> MasterLocations_All(PageParam pageParam, string search, AbstractMasterLocations AbstractMasterLocations = null, int WineId = 0);

        public abstract PagedList<AbstractMasterLocations> MasterLocations_WinesByLocationId(PageParam pageParam, string search, AbstractMasterLocations AbstractMasterLocations = null);

    }
}
