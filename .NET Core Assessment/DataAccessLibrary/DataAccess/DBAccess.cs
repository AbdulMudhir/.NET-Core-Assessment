using _NET_Core_Assessment.Models;
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

        public async Task<FullClassroomModel> GetFullClassRoomData(string query, FullClassroomModel param)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var classroomLookup = new Dictionary<int, FullClassroomModel>();
             

                var data = await connection.QueryAsync< FullClassroomModel, PartialStudentModel, FullClassroomModel>(query,
                    (classroom, student) => {


                        FullClassroomModel classroomEntry;

                        if(!classroomLookup.TryGetValue(classroom.ClassId, out classroomEntry))
                        {
                            classroomEntry = classroom;
                            classroomEntry.Students = new List<PartialStudentModel>();
                            classroomLookup.Add(classroomEntry.ClassId, classroomEntry);

                        }

                        classroomEntry.Students.Add(student);


                        return classroomEntry; 
                    }, param);

                return data.Distinct().FirstOrDefault();
            }
        }

        public  async Task<int> SaveDataAsync<T>(string query, T data)
        {


            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    int index;

                    try
                    {
                        index = await connection.ExecuteScalarAsync<int>(query, data, trans);


                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e}");
                        trans.Rollback();
                        index = 0;
                    }

                    return index;
                }


            }
        }


    }
}
