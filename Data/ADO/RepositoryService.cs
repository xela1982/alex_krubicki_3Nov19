using alex_krubicki_3Nov19.Entities;
using alex_krubicki_3Nov19.Interfaces;
using alex_krubicki_3Nov19.Model;
using alex_krubicki_3Nov19.Repositories.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace alex_krubicki_3Nov19.Data.ADO
{

    public class RepositoryService : IRepository
    {

        private readonly ConnectionStringConfig _connectionStringConfig;
        public RepositoryService(IOptions<ConnectionStringConfig> configAccessor)
        {
            _connectionStringConfig = configAccessor.Value;
        }
        public async Task<List<Company>> GetCompanies()
        {
            var output = new List<Company>();
            var cn = new SqlConnection(_connectionStringConfig.DevConnection);
            var cmd = new SqlCommand("sp_GetCompanies", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            try
            {
                await cn.OpenAsync();
                da.Fill(ds);
                output.AddRange(from DataRow dr in ds.Tables[0].Rows
                                select new Company
                                {
                                    CompanyId = Convert.ToInt32(dr["company_id"]),
                                    CompanyName = Convert.ToString(dr["company_name"])
                                  
                                });
               
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
                cn.Dispose();
            }
            return output;
        }
        public async Task<List<Report>> GetReportByParam(int companyId,  DateTime startDate, DateTime endDate)
        {
            var output = new List<Report>();
            var cn = new SqlConnection(_connectionStringConfig.DevConnection);
            var cmd = new SqlCommand("sp_EmployeesCardsReport", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@company_id", companyId);
            cmd.Parameters.AddWithValue("@start_date", startDate);
            cmd.Parameters.AddWithValue("@end_date", endDate);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            try
            {
                await cn.OpenAsync();
                da.Fill(ds);
                output.AddRange(from DataRow dr in ds.Tables[0].Rows
                                select new Report
                                {
                                    UserId = Convert.ToInt32(dr["user_id"]),
                                    UserFullName = Convert.ToString(dr["full_name"]),
                                    Last4Digits = Convert.ToInt32(dr["last_digit"]),
                                    Payment = Convert.ToDouble(dr["payment_sum"]),
                                });
               
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
                cn.Dispose();
            }
            return output;
        }

    }

}
