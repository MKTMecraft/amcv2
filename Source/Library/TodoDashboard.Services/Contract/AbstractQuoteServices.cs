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
    public abstract class AbstractQuoteServices : AbstractBaseService
    {  
        public abstract PagedList<AbstractQuote> SelectAll(PageParam pageParam, string search);

        public abstract SuccessResult<AbstractQuote> Select(int id);

        public abstract SuccessResult<AbstractQuote> InsertUpdateQuote(AbstractQuote abstractQuote);

        public abstract bool Delete(int id);
        
    }
}
