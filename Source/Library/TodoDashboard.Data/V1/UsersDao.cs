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
   public  class UsersDao : AbstractUsersDao
    {
        public override SuccessResult<AbstractUsers> Login(AbstractUsers abstractUsers)
        {
            SuccessResult<AbstractUsers> users = null;
            var param = new DynamicParameters();

            param.Add("@Email", abstractUsers.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractUsers.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UserLogin, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                users.Item = task.Read<Users>().SingleOrDefault();
            }
            return users;
        }


        public override SuccessResult<AbstractUsers> VerifyEmail(string email)
        {
            SuccessResult<AbstractUsers> users = null;
            var param = new DynamicParameters();

            param.Add("@Email", email, dbType: DbType.String, direction: ParameterDirection.Input);
            
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.VerifyEmail, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                users.Item = task.Read<Users>().SingleOrDefault();
            }
            return users;
        }

        public override int UserPasswordUpdate(AbstractUsers abstractUsers)
        {
            int usersId = -1;
            var param = new DynamicParameters();
          
            param.Add("@Password", abstractUsers.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                if (abstractUsers.Id > 0)
                {
                    param.Add("@Id", abstractUsers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    var task = con.Query<int>(SQLConfig.UserPasswordUpdate, param, commandType: CommandType.StoredProcedure);
                    usersId = task.SingleOrDefault<int>();
                }
            }
            return usersId;
        }

        public override PagedList<AbstractUsers> SelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
            var param = new DynamicParameters();

            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UserSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Users>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractUsers> Select(int id)
        {
            SuccessResult<AbstractUsers> users = null;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.UserSelect, param, commandType: CommandType.StoredProcedure);
                users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                users.Item = task.Read<Users>().SingleOrDefault();
            }
            return users;
        }

        public override SuccessResult<AbstractUsers> InsertUpdateUsers(AbstractUsers abstractusers)
        {
            SuccessResult<AbstractUsers> users = null;
            var param = new DynamicParameters();

            param.Add("@FirstName", abstractusers.FirstName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractusers.LastName, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractusers.Email, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Mobile", abstractusers.Mobile, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractusers.Password, DbType.String, direction: ParameterDirection.Input);
            param.Add("@Isactive", abstractusers.Status, DbType.Boolean, direction: ParameterDirection.Input);
            param.Add("@RoleId", abstractusers.RoleId, DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                if (abstractusers.Id > 0)
                {
                    param.Add("@Id", abstractusers.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    var task = con.QueryMultiple(SQLConfig.UserUpdate, param, commandType: CommandType.StoredProcedure);
                    users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                    users.Item = task.Read<Users>().SingleOrDefault();
                }
                else
                {
                    var task = con.QueryMultiple(SQLConfig.UserInsert, param, commandType: CommandType.StoredProcedure);
                    users = task.Read<SuccessResult<AbstractUsers>>().SingleOrDefault();
                    users.Item = task.Read<Users>().SingleOrDefault();
                }
            }

            return users;
        }

        public override bool Delete(int id)
        {
            bool isDelete = false;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.UserDelete, param, commandType: CommandType.StoredProcedure);
                isDelete = task.SingleOrDefault<bool>();
            }

            return isDelete;
        }

        public override PagedList<AbstractUsers> MenuSelectAll()
        {
            PagedList<AbstractUsers> classes = new PagedList<AbstractUsers>();
            var param = new DynamicParameters();
           
            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.MenuSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Users>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override bool UsersStatusChange(int id)
        {
            bool isDelete = false;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.UsersStatusChange, param, commandType: CommandType.StoredProcedure);
                isDelete = task.SingleOrDefault<bool>();
            }

            return isDelete;
        }
    }
}
