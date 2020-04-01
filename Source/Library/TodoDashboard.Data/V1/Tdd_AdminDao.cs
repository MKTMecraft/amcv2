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
   public  class Tdd_AdminDao : AbstractTdd_AdminDao
    {
        public override bool Tdd_Admin_LastLogin(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Tdd_Admin_LastLogin, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }

            return result;
        }

        public override bool Tdd_Admin_ChangePassword(int Id,string Password)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Tdd_Admin_ChangePassword, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }

            return result;
        }

        public override SuccessResult<AbstractTdd_Admin> Tdd_Admin_Login(string Email, string Password)
        {
            SuccessResult<AbstractTdd_Admin> admin = null;
            var param = new DynamicParameters();

            param.Add("@Email", Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Tdd_Admin_Login, param, commandType: CommandType.StoredProcedure);
                admin = task.Read<SuccessResult<AbstractTdd_Admin>>().SingleOrDefault();
                admin.Item = task.Read<Tdd_Admin>().SingleOrDefault();
            }
            return admin;
        }

        public override SuccessResult<AbstractTdd_Admin> TddAdmin_ById(int Id)
        {
            SuccessResult<AbstractTdd_Admin> admin = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.TddAdmin_ById, param, commandType: CommandType.StoredProcedure);
                admin = task.Read<SuccessResult<AbstractTdd_Admin>>().SingleOrDefault();
                admin.Item = task.Read<Tdd_Admin>().SingleOrDefault();
            }
            return admin;
        }
    }
}
