using Dapper;
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
    public class MasterWineVaritalsDao : AbstractMasterWineVaritalsDao
    {
        public override SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Upsert(AbstractMasterWineVaritals AbstractMasterWineVaritals)
        {
            SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterWineVaritals.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterWineVaritals.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWineVaritals_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterWineVaritals = task.Read<SuccessResult<AbstractMasterWineVaritals>>().SingleOrDefault();
                MasterWineVaritals.Item = task.Read<MasterWineVaritals>().SingleOrDefault();
            }

            return MasterWineVaritals;
        }

        public override SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals_Id(int Id)
        {
            SuccessResult<AbstractMasterWineVaritals> MasterWineVaritals = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWineVaritals_Id, param, commandType: CommandType.StoredProcedure);
                MasterWineVaritals = task.Read<SuccessResult<AbstractMasterWineVaritals>>().SingleOrDefault();
                MasterWineVaritals.Item = task.Read<MasterWineVaritals>().SingleOrDefault();
            }

            return MasterWineVaritals;
        }

        public override PagedList<AbstractMasterWineVaritals> MasterWineVaritals_All(PageParam pageParam,string search, AbstractMasterWineVaritals AbstractMasterWineVaritals = null)
        {
            PagedList<AbstractMasterWineVaritals> MasterWineVaritals = new PagedList<AbstractMasterWineVaritals>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            //param.Add("@Name", AbstractMasterWineVaritals.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWineVaritals_All, param, commandType: CommandType.StoredProcedure);
                MasterWineVaritals.Values.AddRange(task.Read<MasterWineVaritals>());
                MasterWineVaritals.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterWineVaritals;
        }
    }
}
