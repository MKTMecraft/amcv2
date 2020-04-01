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
   public abstract class AbstractTdd_ClientDao : AbstractBaseDao
    {
        public abstract bool Tdd_Client_Delete(int Id);
        public abstract bool Tdd_Client_ActInact(int Id);
        public abstract SuccessResult<AbstractTdd_Client> Tdd_Client_Upsert(AbstractTdd_Client abstractTdd_Client);
        public abstract SuccessResult<AbstractTdd_Client> Tdd_Client_ById(int Id);
        public abstract PagedList<AbstractTdd_Client> Tdd_Client_All(PageParam pageParam, string search);
    }
}
