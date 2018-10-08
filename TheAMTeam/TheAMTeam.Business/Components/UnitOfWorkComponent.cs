using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Components.Interface;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.Business.Components
{
    public class UnitOfWorkComponent : IUnitOfWorkComponent
    {
        private readonly AppContext _context = new AppContext();
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        
        public IArticleComponent Articles { get; set; }
        public ICategoryComponent Categories { get; set; }
        public ICompetitionTypeComponent Competitions { get; set; }
        public IContactComponent Contacts { get; set; }
        public IDepartmentComponent Departments { get; set; }
        public INationalityComponent Nationalities { get; set; }
        public IPlayerComponent Players { get; set; }
        public ITeamComponent Teams { get; set; }

        public UnitOfWorkComponent(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWorkRepository = unitOfWork;
            Players = new PlayerComponent(unitOfWork);
            Articles = new ArticleComponent(unitOfWork);
            Teams = new TeamComponent(unitOfWork);
            Competitions = new CompetitionTypeComponent(unitOfWork);
            Contacts = new ContactComponent(unitOfWork);
        }
    }
}