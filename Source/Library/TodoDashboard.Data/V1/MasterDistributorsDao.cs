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
    public class MasterDistributorsDao : AbstractMasterDistributorsDao
    {
        public override SuccessResult<AbstractMasterDistributors> MasterDistributors_Upsert(AbstractMasterDistributors AbstractMasterDistributors)
        {
            SuccessResult<AbstractMasterDistributors> MasterDistributors = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterDistributors.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterDistributors.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterDistributors_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterDistributors = task.Read<SuccessResult<AbstractMasterDistributors>>().SingleOrDefault();
                MasterDistributors.Item = task.Read<MasterDistributors>().SingleOrDefault();
            }

            return MasterDistributors;
        }

        public override SuccessResult<AbstractMasterDistributors> MasterDistributors_Id(int Id)
        {
            SuccessResult<AbstractMasterDistributors> MasterDistributors = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterDistributors_Id, param, commandType: CommandType.StoredProcedure);
                MasterDistributors = task.Read<SuccessResult<AbstractMasterDistributors>>().SingleOrDefault();
                MasterDistributors.Item = task.Read<MasterDistributors>().SingleOrDefault();
            }

            return MasterDistributors;
        }

        public override PagedList<AbstractMasterDistributors> MasterDistributors_All(PageParam pageParam,string search,AbstractMasterDistributors AbstractMasterDistributors = null)
        {
            PagedList<AbstractMasterDistributors> MasterDistributors = new PagedList<AbstractMasterDistributors>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterDistributors_All, param, commandType: CommandType.StoredProcedure);
                MasterDistributors.Values.AddRange(task.Read<MasterDistributors>());
                MasterDistributors.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterDistributors;
        }
    }
}
