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
    public class MasterLocationsDao : AbstractMasterLocationsDao
    {
        public override SuccessResult<AbstractMasterLocations> MasterLocations_Upsert(AbstractMasterLocations AbstractMasterLocations)
        {
            SuccessResult<AbstractMasterLocations> MasterLocations = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterLocations.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@LocationId", AbstractMasterLocations.LocationId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LocationName", AbstractMasterLocations.LocationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", AbstractMasterLocations.StateId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ServiceTypeId", AbstractMasterLocations.ServiceTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@BarTypeId", AbstractMasterLocations.BarTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterLocations_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterLocations = task.Read<SuccessResult<AbstractMasterLocations>>().SingleOrDefault();
                MasterLocations.Item = task.Read<MasterLocations>().SingleOrDefault();
            }

            return MasterLocations;
        }

        public override SuccessResult<AbstractMasterLocations> MasterLocations_Id(int Id)
        {
            SuccessResult<AbstractMasterLocations> MasterLocations = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterLocations_Id, param, commandType: CommandType.StoredProcedure);
                MasterLocations = task.Read<SuccessResult<AbstractMasterLocations>>().SingleOrDefault();
                MasterLocations.Item = task.Read<MasterLocations>().SingleOrDefault();
            }

            return MasterLocations;
        }

        public override PagedList<AbstractMasterLocations> MasterLocations_All(PageParam pageParam,string search, AbstractMasterLocations AbstractMasterLocations = null, int WineId = 0)
        {
            PagedList<AbstractMasterLocations> MasterLocations = new PagedList<AbstractMasterLocations>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LocationId", AbstractMasterLocations.LocationId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LocationName", AbstractMasterLocations.LocationName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StateId", AbstractMasterLocations.StateId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ServiceTypeId", AbstractMasterLocations.ServiceTypeId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@BarTypeId", AbstractMasterLocations.BarTypeId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@WineId", WineId, dbType: DbType.String, direction: ParameterDirection.Input);
            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterLocations_All, param, commandType: CommandType.StoredProcedure);
                MasterLocations.Values.AddRange(task.Read<MasterLocations>());
                MasterLocations.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterLocations;
        }
        public override PagedList<AbstractMasterLocations> MasterLocations_WinesByLocationId(PageParam pageParam, string search, AbstractMasterLocations AbstractMasterLocations = null)
        {
            PagedList<AbstractMasterLocations> MasterLocations = new PagedList<AbstractMasterLocations>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@LocationId", AbstractMasterLocations.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterLocations_All, param, commandType: CommandType.StoredProcedure);
                MasterLocations.Values.AddRange(task.Read<AbstractMasterLocations>());
                MasterLocations.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterLocations;
        }
    }
}
