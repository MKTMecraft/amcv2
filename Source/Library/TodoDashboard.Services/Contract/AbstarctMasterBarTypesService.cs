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
    public abstract class AbstractMasterBarTypesService
    {
        public abstract SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Upsert(AbstractMasterBarTypes AbstractMasterBarTypes);

        public abstract SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Id(int Id);

        public abstract PagedList<AbstractMasterBarTypes> MasterBarTypes_All(PageParam pageParam, string search, AbstractMasterBarTypes AbstractMasterBarTypes = null);
    }
}
