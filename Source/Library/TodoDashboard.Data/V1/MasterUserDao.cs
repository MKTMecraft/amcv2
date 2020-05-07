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
    public class MasterUserDao : AbstractMasterUserDao
    {
        public override SuccessResult<AbstractMasterUser> MasterUser_Upsert(AbstractMasterUser AbstractMasterUser)
        {
            SuccessResult<AbstractMasterUser> MasterUser = null;
            var param = new DynamicParameters();

            param.Add("@Id", AbstractMasterUser.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Name", AbstractMasterUser.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", AbstractMasterUser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", AbstractMasterUser.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterUser_Upsert, param, commandType: CommandType.StoredProcedure);
                MasterUser = task.Read<SuccessResult<AbstractMasterUser>>().SingleOrDefault();
                MasterUser.Item = task.Read<MasterUser>().SingleOrDefault();
            }

            return MasterUser;
        }

        public override SuccessResult<AbstractMasterUser> MasterUser_Id(int Id)
        {
            SuccessResult<AbstractMasterUser> MasterUser = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterUser_Id, param, commandType: CommandType.StoredProcedure);
                MasterUser = task.Read<SuccessResult<AbstractMasterUser>>().SingleOrDefault();
                MasterUser.Item = task.Read<MasterUser>().SingleOrDefault();
            }

            return MasterUser;
        }

        public override PagedList<AbstractMasterUser> MasterUser_All(PageParam pageParam, string search, AbstractMasterUser AbstractMasterUser = null)
        {
            PagedList<AbstractMasterUser> MasterUser = new PagedList<AbstractMasterUser>();

            var param = new DynamicParameters();
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterUser_All, param, commandType: CommandType.StoredProcedure);
                MasterUser.Values.AddRange(task.Read<MasterUser>());
                MasterUser.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return MasterUser;
        }

        public override SuccessResult<AbstractMasterUser> MasterUser_Login(AbstractMasterUser abstractMasterUser)
        {
            SuccessResult<AbstractMasterUser> client = null;
            var param = new DynamicParameters();

            param.Add("@Email", abstractMasterUser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractMasterUser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MasterUser_Login, param, commandType: CommandType.StoredProcedure);
                client = task.Read<SuccessResult<AbstractMasterUser>>().SingleOrDefault();
                client.Item = task.Read<MasterUser>().SingleOrDefault();
            }
            return client;
        }

        public override bool MasterUser_ChangePassword(MasterUser masterUser)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", masterUser.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Password", masterUser.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.MasterUser_ChangePassword, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }

            return result;
        }

        //public override bool MasterUser_ActInact(int Id)
        //{
        //    bool result = false;
        //    var param = new DynamicParameters();

        //    param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
        //    {
        //        var task = con.Query<bool>(SQLConfig.MasterUser_ActInact, param, commandType: CommandType.StoredProcedure);
        //        result = task.SingleOrDefault<bool>();
        //    }

        //    return result;
        //}
    }
}
