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
    public abstract class AbstractMasterWinesDao
    {
        public abstract SuccessResult<AbstractMasterWines> MasterWines_Upsert(AbstractMasterWines AbstractMasterWines);

        public abstract SuccessResult<AbstractMasterWines> MasterWines_Id(int Id);

        public abstract PagedList<AbstractMasterWines> MasterWines_All(PageParam pageParam, string search, AbstractMasterWines AbstractMasterWines = null, int LocationId = 0);
    }
}
