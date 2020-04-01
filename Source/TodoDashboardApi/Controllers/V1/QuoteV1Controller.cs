using TodoDashboard.APICommon;
using TodoDashboardApi.Models;
using TodoDashboard.Common;
using TodoDashboardApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TodoDashboard.Common.Paging;
using TodoDashboard.Services.Contract;
using TodoDashboard.Entities.Contract;

namespace TodoDashboardApi.Controllers.V1
{
    public class QuoteV1Controller : AbstractBaseController
    {
        #region Fields
        private readonly AbstractQuoteServices quoteServices;

        #endregion

        #region Cnstr
        public QuoteV1Controller(AbstractQuoteServices quoteServices)
        {
            this.quoteServices = quoteServices;
        }
        #endregion

        [System.Web.Http.HttpPost]
        [InheritedRoute("quoteUpsert")]
        public async Task<IHttpActionResult> quoteUpsert(AbstractQuote quoteObj)
        {
            var quote = quoteServices.InsertUpdateQuote(quoteObj);
            return this.Content((HttpStatusCode)quote.Code, quote);
        }
    }
}