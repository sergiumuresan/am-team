using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class DepartmentRepository
    {
        public List<Department> GetAll()
        {
            List<Department> dbDepartments;
            try
            {
                using (var context = new AppContext())
                {
                    dbDepartments = context.Departments.ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
            return dbDepartments;
        }
    }
}
