using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;

namespace TodoDashboard.Services.Contract
{
    public abstract class AbstractMasterServicesTypesService
    {
        public abstract SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes_Upsert(AbstractMasterServicesTypes AbstractMasterServicesTypes);

        public abstract SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes_Id(int Id);

        public abstract PagedList<AbstractMasterServicesTypes> MasterServicesTypes_All(PageParam pageParam, string search, AbstractMasterServicesTypes AbstractMasterServicesTypes = null);
    }
}
