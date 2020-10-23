using _NET_Core_Assessment.DataAccessLibrary.DataAccess;
using _NET_Core_Assessment.Models;
using _NET_Core_Assessment.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.DataAccessLibrary.BusinessLogic
{
    public class StudentManager
    {
        private readonly DBAccess _dbAccess;
        private readonly ClassroomManager _classroomManager;

        public StudentManager(DBAccess dbAccess, ClassroomManager classroomManager)
        {
            _dbAccess = dbAccess;
            _classroomManager = classroomManager;
        }

        public async Task<int> AddStudent(StudentModel student)
        {
            var query = "INSERT INTO Student (FirstName, LastName, Age, ClassId) OUTPUT INSERTED.StudentId " +
                "VALUES (@FirstName, @LastName, @Age, @ClassId)";

            return await _dbAccess.SaveDataAsync<StudentModel>(query, student);
        }

        public async Task<StudentModel> GetStudent(StudentPostModel studentPost)
        {
            // incase to prevent duplicates would validate all the properties 
            var query = "Select * From Students WHERE FirstName =@FirstName AND LastName=@LastName AND Age=@Age AND ClassId=@ClassId";

            var data = await _dbAccess.GetData<StudentModel>
                (query, new StudentModel
                {
                    FirstName = studentPost.FirstName,
                    LastName = studentPost.LastName,
                    Age = studentPost.Age,
                    ClassId = studentPost.ClassId
                });

            return data.FirstOrDefault();
        }


    }
}
