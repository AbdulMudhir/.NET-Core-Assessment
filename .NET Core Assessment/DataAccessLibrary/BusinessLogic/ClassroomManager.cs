﻿using _NET_Core_Assessment.DataAccessLibrary.DataAccess;
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

    }
}
