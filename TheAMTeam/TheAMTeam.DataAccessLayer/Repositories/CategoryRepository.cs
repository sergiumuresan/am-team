using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppContext _context;

        public CategoryRepository(AppContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            try
            {
                using(var context = new AppContext())
                {
                    return context.Categories.ToList();
                }
            }catch(Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }
        }
    }
}
