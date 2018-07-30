using System;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class CompetitionController : Controller
    {

        private static CompetitionTypeComponent component = new CompetitionTypeComponent();
        // GET: Competition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var competition = component.GetAllCompetionType();
            
            return View(competition);
        }

        public ActionResult AddComp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompetition(CompetitionTypeModel addComp)
        {
            if (ModelState.IsValid)
            {
                component.Add(addComp);
            }
            return RedirectToAction("GetAll");
        }

        public ActionResult Edit(int id)
        {
            var matchingCompetition = component.GetById(id);
            if(matchingCompetition == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingCompetition);
        }

        [HttpPost]
        public ActionResult EditCompetition(CompetitionTypeModel  competition)
        {
            var matchingCompetition = component.GetById(competition.CompetitionTypeId);
            if (matchingCompetition != null)
            {
                matchingCompetition.Name = competition.Name;
                component.Update(matchingCompetition);
            }
            
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            var matchingCompetition = component.Delete(id);
            return RedirectToAction("GetAll");
            
        }
    }
}