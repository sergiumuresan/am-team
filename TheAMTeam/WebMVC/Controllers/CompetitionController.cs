using System;
using System.Linq;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interface;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly IUnitOfWorkComponent _unitOfWorkComponent;

        public CompetitionController(IUnitOfWorkComponent unitOfWorkComponent)
        {
            _unitOfWorkComponent = unitOfWorkComponent;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var competition = _unitOfWorkComponent.Competitions.GetAllCompetionType();
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
                _unitOfWorkComponent.Competitions.Add(addComp);
            }
            return RedirectToAction("GetAll");
        }

        public ActionResult Edit(int id)
        {
            var matchingCompetition = _unitOfWorkComponent.Competitions.GetById(id);
            if (matchingCompetition == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingCompetition);
        }

        [HttpPost]
        public ActionResult EditCompetition(CompetitionTypeModel competition)
        {
            var matchingCompetition = _unitOfWorkComponent.Competitions.GetById(competition.CompetitionTypeId);
            if (matchingCompetition != null)
            {
                matchingCompetition.Name = competition.Name;
                _unitOfWorkComponent.Competitions.Update(matchingCompetition);
            }

            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            var matchingCompetition = _unitOfWorkComponent.Competitions.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult getAllSearch(String search)
        {
            var competition = _unitOfWorkComponent.Competitions.GetAllCompetionType();
            var searchResult = competition.Where(x => x.Name.Contains(search));
            return View(searchResult);
        }

    }
}