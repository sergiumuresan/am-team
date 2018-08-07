using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;
using TheAMTeam.Business.Components.Interfaces;
using TheAMTeam.Business.Components.Interfaces.Components;

namespace TheAMTeam.Business.Components
{
    public class UnitOfWorkComponent : IUnitOfWorkComponent
    {
        private readonly AppContext _context;

        public IArticleComponent Articles { get; set ; }
        public ICompetitionTypeComponent CompetitionTypes { get; set; }
        public IContactComponent ContactComponents { get; set ; }
        public IDepartmentComponent Departments { get; set ; }
        public INationalityComponent Nationalities { get; set; }
        public IPlayerComp Players { get; set; }
        public ITeamComponent Teams { get; set ; }

        public UnitOfWorkComponent(AppContext context)
        {
            _context = context;
            Articles = new ArticleComponent();
            CompetitionTypes = new CompetitionTypeComponent();
            ContactComponents = new ContactComponent();
            Departments = new DepartmentComponent();
            Nationalities = new NationalityComponent();
            Players = new PlayerComp(context);
            Teams = new TeamComponent();
        }

        public UnitOfWorkComponent()
        {
            Articles = new ArticleComponent();
            CompetitionTypes = new CompetitionTypeComponent();
            ContactComponents = new ContactComponent();
            Departments = new DepartmentComponent();
            Nationalities = new NationalityComponent();
            Players = new PlayerComp();
            Teams = new TeamComponent();
        }

        //public UnitOfWorkComponent()
        //{

        //    Articles = new ArticleComponent();
        //    CompetitionTypes = new CompetitionTypeComponent();
        //    ContactComponents = new ContactComponent();
        //    Departments = new DepartmentComponent();
        //    Nationalities = new NationalityComponent();
        //    Players = new PlayerComp(context);
        //    Teams = new TeamComponent();
        //}
    }
}