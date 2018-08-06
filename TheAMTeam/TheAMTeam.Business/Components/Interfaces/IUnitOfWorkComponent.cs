using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheAMTeam.Business.Components.Interfaces.Components
{
    public interface IUnitOfWorkComponent
    {
        IArticleComponent Articles { get; set; }
        ICompetitionTypeComponent CompetitionTypes { get; set; }
        IContactComponent ContactComponents { get; set; }
        IDepartmentComponent Departments { get; set; }
        INationalityComponent Nationalities { get; set; }   
        IPlayerComp Players { get; set; }
        ITeamComponent Components { get; set; }
        ITeamComponent Teams { get; set; }
    }
}