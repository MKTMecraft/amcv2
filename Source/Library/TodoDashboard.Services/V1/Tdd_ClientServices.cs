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
    public class Tdd_ClientServices : AbstractTdd_ClientServices
    {
        private AbstractTdd_ClientDao abstractTdd_ClientDao;

        public Tdd_ClientServices(AbstractTdd_ClientDao abstractTdd_ClientDao)
        {
            this.abstractTdd_ClientDao = abstractTdd_ClientDao;
        }

        public override bool Tdd_Client_Delete(string Id)
        {
            return abstractTdd_ClientDao.Tdd_Client_Delete(ConvertTo.Integer(ConvertTo.Base64Decode(Id)));
        }

        public override bool Tdd_Client_ActInact(string Id)
        {
            return abstractTdd_ClientDao.Tdd_Client_ActInact(ConvertTo.Integer(ConvertTo.Base64Decode(Id)));
        }

        public override SuccessResult<AbstractTdd_Client> Tdd_Client_Upsert(AbstractTdd_Client abstractTdd_Client)
        {
            abstractTdd_Client.Id = ConvertTo.Integer(ConvertTo.Base64Decode(abstractTdd_Client.IdStr));
            return abstractTdd_ClientDao.Tdd_Client_Upsert(abstractTdd_Client);
        }

        public override SuccessResult<AbstractTdd_Client> Tdd_Client_ById(string Id)
        {
            return abstractTdd_ClientDao.Tdd_Client_ById(ConvertTo.Integer(ConvertTo.Base64Decode(Id)));
        }

        public override PagedList<AbstractTdd_Client> Tdd_Client_All(PageParam pageParam, string search)
        {
            return abstractTdd_ClientDao.Tdd_Client_All(pageParam,search);
        }
    }
}
