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
    public class Tdd_ClientDao : AbstractTdd_ClientDao
    {
        public override bool Tdd_Client_Delete(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Tdd_Client_Delete, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }

            return result;
        }

        public override bool Tdd_Client_ActInact(int Id)
        {
            bool result = false;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.Query<bool>(SQLConfig.Tdd_Client_ActInact, param, commandType: CommandType.StoredProcedure);
                result = task.SingleOrDefault<bool>();
            }

            return result;
        }

        public override SuccessResult<AbstractTdd_Client> Tdd_Client_Upsert(AbstractTdd_Client abstractTdd_Client)
        {
            SuccessResult<AbstractTdd_Client> client = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractTdd_Client.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@FirstName", abstractTdd_Client.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@LastName", abstractTdd_Client.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Gender", abstractTdd_Client.Gender, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@DOB", abstractTdd_Client.DOB.ToString("yyyy-MM-dd"), dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@MobileNo", abstractTdd_Client.MobileNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Email", abstractTdd_Client.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Password", abstractTdd_Client.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AddressLine1", abstractTdd_Client.AddressLine1, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AddressLine2", abstractTdd_Client.AddressLine2, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@City", abstractTdd_Client.City, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@State", abstractTdd_Client.State, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Zip", abstractTdd_Client.Zip, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Country", abstractTdd_Client.Country, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Tdd_Client_Upsert, param, commandType: CommandType.StoredProcedure);
                client = task.Read<SuccessResult<AbstractTdd_Client>>().SingleOrDefault();
                client.Item = task.Read<Tdd_Client>().SingleOrDefault();
            }
            return client;
        }

        public override SuccessResult<AbstractTdd_Client> Tdd_Client_ById(int Id)
        {
            SuccessResult<AbstractTdd_Client> client = null;
            var param = new DynamicParameters();

            param.Add("@Id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Tdd_Client_Id, param, commandType: CommandType.StoredProcedure);
                client = task.Read<SuccessResult<AbstractTdd_Client>>().SingleOrDefault();
                client.Item = task.Read<Tdd_Client>().SingleOrDefault();
            }
            return client;
        }

        public override PagedList<AbstractTdd_Client> Tdd_Client_All(PageParam pageParam, string search)
        {
            PagedList<AbstractTdd_Client> classes = new PagedList<AbstractTdd_Client>();
            var param = new DynamicParameters();

            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.Tdd_Client_All, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Tdd_Client>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }
    }
}
