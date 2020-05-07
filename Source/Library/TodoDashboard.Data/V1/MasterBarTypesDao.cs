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
    public class MasterBarTypesDao : AbstractMasterBarTypesDao
    {
        public override SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Upsert(AbstractMasterBarTypes AbstractMasterBarTypes)
        {
            SuccessResult<AbstractMasterBarTypes> MasterBarTypes = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterBarTypes.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterBarTypes.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterBarTypes_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterBarTypes = task.Read<SuccessResult<AbstractMasterBarTypes>>().SingleOrDefault();
                MasterBarTypes.Item = task.Read<MasterBarTypes>().SingleOrDefault();
            }

            return MasterBarTypes;
        }

        public override SuccessResult<AbstractMasterBarTypes> MasterBarTypes_Id(int Id)
        {
            SuccessResult<AbstractMasterBarTypes> MasterBarTypes = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterBarTypes_Id, param, commandType: CommandType.StoredProcedure);
                MasterBarTypes = task.Read<SuccessResult<AbstractMasterBarTypes>>().SingleOrDefault();
                MasterBarTypes.Item = task.Read<MasterBarTypes>().SingleOrDefault();
            }

            return MasterBarTypes;
        }

        public override PagedList<AbstractMasterBarTypes> MasterBarTypes_All(PageParam pageParam,string search, AbstractMasterBarTypes AbstractMasterBarTypes = null)
        {
            PagedList<AbstractMasterBarTypes> MasterBarTypes = new PagedList<AbstractMasterBarTypes>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterBarTypes_All, param, commandType: CommandType.StoredProcedure);
                MasterBarTypes.Values.AddRange(task.Read<MasterBarTypes>());
                MasterBarTypes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterBarTypes;
        }
    }
}
