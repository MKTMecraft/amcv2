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
    public class MasterTiersDao : AbstractMasterTiersDao
    {
        public override SuccessResult<AbstractMasterTiers> MasterTiers_Upsert(AbstractMasterTiers AbstractMasterTiers)
        {
            SuccessResult<AbstractMasterTiers> MasterTiers = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterTiers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterTiers.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterTiers_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterTiers = task.Read<SuccessResult<AbstractMasterTiers>>().SingleOrDefault();
                MasterTiers.Item = task.Read<MasterTiers>().SingleOrDefault();
            }

            return MasterTiers;
        }

        public override SuccessResult<AbstractMasterTiers> MasterTiers_Id(int Id)
        {
            SuccessResult<AbstractMasterTiers> MasterTiers = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterTiers_Id, param, commandType: CommandType.StoredProcedure);
                MasterTiers = task.Read<SuccessResult<AbstractMasterTiers>>().SingleOrDefault();
                MasterTiers.Item = task.Read<MasterTiers>().SingleOrDefault();
            }

            return MasterTiers;
        }

        public override PagedList<AbstractMasterTiers> MasterTiers_All(PageParam pageParam,string search, AbstractMasterTiers AbstractMasterTiers = null)
        {
            PagedList<AbstractMasterTiers> MasterTiers = new PagedList<AbstractMasterTiers>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterTiers_All, param, commandType: CommandType.StoredProcedure);
                MasterTiers.Values.AddRange(task.Read<MasterTiers>());
                MasterTiers.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterTiers;
        }
    }
}
