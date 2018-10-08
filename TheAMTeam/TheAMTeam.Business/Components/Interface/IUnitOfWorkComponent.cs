using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Components.Interface.Components;

namespace TheAMTeam.Business.Components.Interface
{
    public interface IUnitOfWorkComponent
    {
        IArticleComponent Articles { get; set; }
        ICategoryComponent Categories { get; set; }
        ICompetitionTypeComponent Competitions { get; set; }
        IContactComponent Contacts { get; set; }
        IDepartmentComponent Departments { get; set; }
        INationalityComponent Nationalities { get; set; }
        IPlayerComponent Players { get; set; }
        ITeamComponent Teams { get; set; }
        
        
    }
}
