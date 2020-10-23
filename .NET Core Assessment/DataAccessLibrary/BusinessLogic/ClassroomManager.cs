using _NET_Core_Assessment.DataAccessLibrary.DataAccess;
using _NET_Core_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.DataAccessLibrary.BusinessLogic
{
    public class ClassroomManager
    {
        private readonly DBAccess _dbAccess;

        public ClassroomManager(DBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }


        public async Task<ClassModel> GetClass(ClassPostModel classPost)
        {
            var query = "Select * From Classes WHERE ClassName=@ClassName AND School =@School";

            var data = await _dbAccess.GetData<ClassModel>
                (query, new ClassModel { ClassName= classPost.ClassName, School= classPost.School });

            return data.FirstOrDefault();
        }
        public async Task<ClassModel> GetClassById(int classId)
        {
            var query = "Select * From Classes WHERE ClassId=@ClassId";

            var data = await _dbAccess.GetData<ClassModel>
                (query, new ClassModel { ClassId= classId });

            return data.FirstOrDefault();
        }


        public async Task<int> AddClass(ClassModel classModel)
        {
            var query = "INSERT INTO Classes (ClassName, School, Grade) OUTPUT INSERTED.ClassID VALUES (@ClassName, @School, @Grade)";

            var data = await _dbAccess.SaveDataAsync<ClassModel>(query, classModel);

            return data;
        }

        public async Task<List<ClassModel>> GetAllClasses()
        {
            var query = "Select * From Classes";

           var data = await _dbAccess.GetData<ClassModel>(query, null);

            return data;
        }


        public async Task<List<string>> GetAllClassesByName()
        {
            var query = "Select ClassName From Classes";

            var data = await _dbAccess.GetData<ClassModel>(query, null);

            return data.Select(c => c.ClassName).ToList();
        }

        public async Task<List<PartialStudentModel>> GetAllStudentsFromClassName(string classname)
        {
            var query = "Select C.*, S.FirstName,S.LastName, From Classes AS C LEFT JOIN Students AS S ON s.ClassId = C.ClassID WHERE C.ClassName=@ClassName";

            var data = await _dbAccess.GetFullClassRoomData(query, new FullClassroomModel { ClassName = classname});

            return data.Students;
        }

    }
}
