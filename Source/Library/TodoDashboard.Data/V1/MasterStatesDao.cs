using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDashboard.Common;
using TodoDashboard.Common.Paging;
using TodoDashboard.Data.Contract;
using TodoDashboard.Entities.Contract;
using TodoDashboard.Entities.V1;

namespace TodoDashboard.Data.V1
{
    public class MasterStatesDao : AbstractMasterStatesDao
    {

        public override PagedList<AbstractMasterStates> MasterStates_All(PageParam pageParam,string search, AbstractMasterStates AbstractMasterStates = null)
        {
            PagedList<AbstractMasterStates> MasterStates = new PagedList<AbstractMasterStates>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
           // param.Add("@Name", AbstractMasterStates.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterStates_All, param, commandType: CommandType.StoredProcedure);
                MasterStates.Values.AddRange(task.Read<MasterStates>());
                MasterStates.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterStates;
        }
    }
}
