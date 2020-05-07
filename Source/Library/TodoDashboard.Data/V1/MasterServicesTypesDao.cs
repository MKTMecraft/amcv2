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
    public class MasterServicesTypesDao : AbstractMasterServicesTypesDao
    {
        public override SuccessResult<AbstractMasterServicesTypes> MasterServicesType_Upsert(AbstractMasterServicesTypes AbstractMasterServicesTypes)
        {
            SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterServicesTypes.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterServicesTypes.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterServicesTypes_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterServicesTypes = task.Read<SuccessResult<AbstractMasterServicesTypes>>().SingleOrDefault();
                MasterServicesTypes.Item = task.Read<MasterServicesTypes>().SingleOrDefault();
            }

            return MasterServicesTypes;
        }

        public override SuccessResult<AbstractMasterServicesTypes> MasterServicesType_Id(int Id)
        {
            SuccessResult<AbstractMasterServicesTypes> MasterServicesTypes = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterServicesTypes_Id, param, commandType: CommandType.StoredProcedure);
                MasterServicesTypes = task.Read<SuccessResult<AbstractMasterServicesTypes>>().SingleOrDefault();
                MasterServicesTypes.Item = task.Read<MasterServicesTypes>().SingleOrDefault();
            }

            return MasterServicesTypes;
        }

        public override PagedList<AbstractMasterServicesTypes> MasterServicesType_All(PageParam pageParam,string search, AbstractMasterServicesTypes AbstractMasterServicesTypes = null)
        {
            PagedList<AbstractMasterServicesTypes> MasterServicesTypes = new PagedList<AbstractMasterServicesTypes>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterServicesTypes_All, param, commandType: CommandType.StoredProcedure);
                MasterServicesTypes.Values.AddRange(task.Read<MasterServicesTypes>());
                MasterServicesTypes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterServicesTypes;
        }
    }
}
