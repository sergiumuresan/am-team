using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;


namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppContext _context;

        public DepartmentRepository()
        {
        }

        public DepartmentRepository(AppContext context)
        {
            _context = context;
        }

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
