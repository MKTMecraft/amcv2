using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;

namespace TodoDashboard.Data.Contract
{
    public abstract class AbstractMasterUserDao
    {
        public abstract SuccessResult<AbstractMasterUser> MasterUser_Upsert(AbstractMasterUser AbstractMasterUser);

        public abstract SuccessResult<AbstractMasterUser> MasterUser_Id(int Id);

        public abstract PagedList<AbstractMasterUser> MasterUser_All(PageParam pageParam, string search, AbstractMasterUser AbstractMasterUser = null);

        public abstract SuccessResult<AbstractMasterUser> MasterUser_Login(AbstractMasterUser abstractMasterUser);

        public abstract bool MasterUser_ChangePassword(MasterUser masterUser);
        //public abstract override bool MasterUser_ActInact(int Id);
    }
}
