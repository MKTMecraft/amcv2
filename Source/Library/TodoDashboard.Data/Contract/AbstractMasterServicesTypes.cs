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
    public abstract class AbstractMasterServicesTypesDao
    {
        public abstract SuccessResult<AbstractMasterServicesTypes> MasterServicesType_Upsert(AbstractMasterServicesTypes AbstractMasterServicesTypes);

        public abstract SuccessResult<AbstractMasterServicesTypes> MasterServicesType_Id(int Id);

        public abstract PagedList<AbstractMasterServicesTypes> MasterServicesType_All(PageParam pageParam, string search, AbstractMasterServicesTypes AbstractMasterServicesTypes = null);
    }
}
