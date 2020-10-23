using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.DataAccessLibrary.DataAccess
{
    public class DBAccess
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DBAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public  async Task<List<T>> GetData<T>(string query, T param)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var data = await connection.QueryAsync<T>(query, param);

                return data.ToList();
            }
        }


    }
}
