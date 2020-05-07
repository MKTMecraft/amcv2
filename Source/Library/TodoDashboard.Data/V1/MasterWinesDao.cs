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
    public class MasterWinesDao : AbstractMasterWinesDao
    {
        public override SuccessResult<AbstractMasterWines> MasterWines_Upsert(AbstractMasterWines AbstractMasterWines)
        {
            SuccessResult<AbstractMasterWines> MasterWines = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterWines.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@WineName", AbstractMasterWines.WineName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MasterVarietalId", AbstractMasterWines.MasterVarietalId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Calories", AbstractMasterWines.Calories, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MasterDistributorId", AbstractMasterWines.MasterDistributorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TierId", AbstractMasterWines.TierId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWines_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterWines = task.Read<SuccessResult<AbstractMasterWines>>().SingleOrDefault();
                MasterWines.Item = task.Read<MasterWines>().SingleOrDefault();
            }

            return MasterWines;
        }

        public override SuccessResult<AbstractMasterWines> MasterWines_Id(int Id)
        {
            SuccessResult<AbstractMasterWines> MasterWines = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWines_Id, param, commandType: CommandType.StoredProcedure);
                MasterWines = task.Read<SuccessResult<AbstractMasterWines>>().SingleOrDefault();
                MasterWines.Item = task.Read<MasterWines>().SingleOrDefault();
            }

            return MasterWines;
        }

        public override PagedList<AbstractMasterWines> MasterWines_All(PageParam pageParam,string search, AbstractMasterWines AbstractMasterWines = null, int LocationId = 0)
        {
            PagedList<AbstractMasterWines> MasterWines = new PagedList<AbstractMasterWines>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@WineName", AbstractMasterWines.WineName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MasterVarietalId", AbstractMasterWines.MasterVarietalId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Calories", AbstractMasterWines.Calories, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MasterDistributorId", AbstractMasterWines.MasterDistributorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@TierId", AbstractMasterWines.TierId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@LocationId", LocationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterWines_All, param, commandType: CommandType.StoredProcedure);
                MasterWines.Values.AddRange(task.Read<MasterWines>());
                MasterWines.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterWines;
        }
    }
}
