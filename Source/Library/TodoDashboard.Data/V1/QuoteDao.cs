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
    public class QuoteDao : AbstractQuoteDao
    {
        public override PagedList<AbstractQuote> SelectAll(PageParam pageParam, string search)
        {
            PagedList<AbstractQuote> classes = new PagedList<AbstractQuote>();
            var param = new DynamicParameters();

            param.Add("@Search", search, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Offset", pageParam.Offset, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Limit", pageParam.Limit, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.QuoteSelectAll, param, commandType: CommandType.StoredProcedure);
                classes.Values.AddRange(task.Read<Quote>());
                classes.TotalRecords = task.Read<long>().SingleOrDefault();
            }
            return classes;
        }

        public override SuccessResult<AbstractQuote> Select(int id)
        {
            SuccessResult<AbstractQuote> Quote = null;
            var param = new DynamicParameters();

            param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.QuoteSelect, param, commandType: CommandType.StoredProcedure);
                Quote = task.Read<SuccessResult<AbstractQuote>>().SingleOrDefault();
                Quote.Item = task.Read<Quote>().SingleOrDefault();
            }
            return Quote;
        }

        public override SuccessResult<AbstractQuote> InsertUpdateQuote(AbstractQuote abstractQuote)
        {
            SuccessResult<AbstractQuote> Quote = null;
            var param = new DynamicParameters();

            param.Add("@Id", abstractQuote.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@ServiceType", abstractQuote.ServiceType, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PostalCode", abstractQuote.PostalCode, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PropertyLayout", abstractQuote.PropertyLayout, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Floor", abstractQuote.Floor, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Bedroom", abstractQuote.Bedroom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Bathroom", abstractQuote.Bathroom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Extras", abstractQuote.Extras, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@PropertyCondition", abstractQuote.PropertyCondition, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@CleaningType", abstractQuote.CleaningType, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@CleaningPrefDay", abstractQuote.CleaningPrefDay, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PropertyAddress", abstractQuote.PropertyAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ApplyCodes", abstractQuote.ApplyCodes, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ServiceDate", abstractQuote.ServiceDate, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@ServiceTime", abstractQuote.ServiceTime, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@FlexibleDateTime", abstractQuote.FlexibleDateTime, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@GainAccess", abstractQuote.GainAccess, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@GainAccessDescription", abstractQuote.GainAccessDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Park", abstractQuote.Park, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@AdditionalInformation", abstractQuote.AdditionalInformation, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@UploadDoc", abstractQuote.UploadDoc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Tip", abstractQuote.Tip, dbType: DbType.String, direction: ParameterDirection.Input);


            using (SqlConnection con = new SqlConnection(Configurations.ConnectionString))
            {
                var task = con.QueryMultiple(SQLConfig.QuoteUpsert, param, commandType: CommandType.StoredProcedure);
                Quote = task.Read<SuccessResult<AbstractQuote>>().SingleOrDefault();
                Quote.Item = task.Read<Quote>().SingleOrDefault();
            }

            return Quote;
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
    }
}
