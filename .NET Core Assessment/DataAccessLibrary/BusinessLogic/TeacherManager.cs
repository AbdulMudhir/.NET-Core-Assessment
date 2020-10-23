using _NET_Core_Assessment.DataAccessLibrary.DataAccess;
using _NET_Core_Assessment.Models;
using _NET_Core_Assessment.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.DataAccessLibrary.BusinessLogic
{
    public class TeacherManager
    {
        private readonly DBAccess _dbAccess;

        public TeacherManager(DBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task<int> AddTeacher(TeacherModel teacher)
        {
            var query = "INSERT INTO Teacher (FirstName, LastName, Age, Subject) OUTPUT INSERTED.TeacherId " +
                "VALUES (@FirstName, @LastName, @Age, @Subject)";

            return await _dbAccess.SaveDataAsync<TeacherModel>(query, teacher);
        }

        public async Task<TeacherModel> GetTeacher(TeacherPostModel teacherPost)
        {
            // incase to prevent duplicates would validate all the properties 
            var query = "Select * From Teacher WHERE FirstName =@FirstName AND LastName=@LastName AND Age=@Age AND Subject=@Subject";

            var data = await _dbAccess.GetData<TeacherModel>
                (query, new TeacherModel { FirstName = teacherPost.FirstName, LastName= teacherPost.LastName, Age = teacherPost.Age,
                    Subject = teacherPost.Subject});

            return data.FirstOrDefault();
        }

        public async Task<TeacherClassesModel> GetTeacherIDByClassId(int teacherId, int classroomId)
        {
            // incase to prevent duplicates would validate all the properties 
            var query = "Select * From TeacherClasses WHERE TeacherId=@TeacherId AND ClassId=@ClassId";

            var data = await _dbAccess.GetData<TeacherClassesModel>
                (query, new TeacherClassesModel
                {
                   TeacherId = teacherId,
                   ClassId = classroomId
                });

            return data.FirstOrDefault();
        }

        public async Task<TeacherModel> GetTeacherById(int  teacherId)
        {
            // incase to prevent duplicates would validate all the properties 
            var query = "Select * From Teacher WHERE TeacherId=@TeacherId";

            var data = await _dbAccess.GetData<TeacherModel>
                (query, new TeacherModel
                {
                    TeacherId = teacherId
                });

            return data.FirstOrDefault();
        }



    }
}
