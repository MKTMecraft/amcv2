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
    public abstract class AbstractMasterTiersService
    {
        public abstract SuccessResult<AbstractMasterTiers> MasterTiers_Upsert(AbstractMasterTiers AbstractMasterTiers);

        public abstract SuccessResult<AbstractMasterTiers> MasterTiers_Id(int Id);

        public abstract PagedList<AbstractMasterTiers> MasterTiers_All(PageParam pageParam, string search, AbstractMasterTiers AbstractMasterTiers = null);
    }
}
