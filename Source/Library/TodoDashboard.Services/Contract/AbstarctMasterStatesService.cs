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
    public abstract class AbstractMasterStatesService
    {
        public abstract PagedList<AbstractMasterStates> MasterStates_All(PageParam pageParam, string search, AbstractMasterStates AbstractMasterStates = null);
    }
}
