using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interface.Components
{
    public interface ICategoryComponent
    {
        List<CategoryModel> GetAll();
    }
}
