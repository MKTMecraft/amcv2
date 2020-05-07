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
    public abstract class AbstractMasterWineVaritalsService
    {
        public abstract SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Upsert(AbstractMasterWineVaritals AbstractMasterWineVaritals);

        public abstract SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Id(int Id);

        public abstract PagedList<AbstractMasterWineVaritals> MasterWineVaritals_All(PageParam pageParam, string search, AbstractMasterWineVaritals AbstractMasterWineVaritals = null);
    }
}
