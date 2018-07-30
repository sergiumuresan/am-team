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
        //public ActionResult GetById(int id)
        //{
        //    var byId = comp.GetById(id);
        //    return view(byId);
        //}

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

        public ActionResult Edit(CompetitionTypeModel editComp)
        {
            var matchingCompetition = component.GetById(editComp.CompetitionTypeId);
            if (matchingCompetition == null)
            {
                return RedirectToAction("GetAll");
            }

            matchingCompetition.CompetitionTypeId = matchingCompetition.CompetitionTypeId;
            matchingCompetition.Name = editComp.Name;

            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            var matchingCompetition = component.Delete(id);
            return RedirectToAction("GetAll");
            
        }
    }
}