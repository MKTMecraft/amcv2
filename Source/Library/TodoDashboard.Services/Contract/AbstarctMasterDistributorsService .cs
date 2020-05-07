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
    public abstract class AbstractMasterDistributorsService
    {
        public abstract SuccessResult<AbstractMasterDistributors> MasterDistributors_Upsert(AbstractMasterDistributors AbstractMasterDistributors);

        public abstract SuccessResult<AbstractMasterDistributors> MasterDistributors_Id(int Id);

        public abstract PagedList<AbstractMasterDistributors> MasterDistributors_All(PageParam pageParam, string search, AbstractMasterDistributors AbstractMasterDistributors = null);
    }
}
