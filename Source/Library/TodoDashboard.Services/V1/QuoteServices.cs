using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Data.Contract;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Services.Contract;

namespace TodoDashboard.Services.V1
{
    public class QuoteServices : AbstractQuoteServices
    {
        private AbstractQuoteDao abstractQuoteDao;

        public QuoteServices (AbstractQuoteDao abstractQuoteDao)
        {
            this.abstractQuoteDao = abstractQuoteDao;
        }

        public override PagedList<AbstractQuote> SelectAll(PageParam pageParam, string search)
        {
            return this.abstractQuoteDao.SelectAll(pageParam, search);
        }

        public override SuccessResult<AbstractQuote> Select(int id)
        {
            return this.abstractQuoteDao.Select(id);
        }

        public override SuccessResult<AbstractQuote> InsertUpdateQuote(AbstractQuote abstractQuote)
        {
            SuccessResult<AbstractQuote> result = this.abstractQuoteDao.InsertUpdateQuote(abstractQuote);
            return result;
        }

        public override bool Delete(int id)
        {
            return this.abstractQuoteDao.Delete(id);
        }
    }
}
