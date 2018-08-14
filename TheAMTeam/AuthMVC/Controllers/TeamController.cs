using AuthMVC;
using System;
using System.Linq;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;
using TheAMTeam.WebMVC.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class TeamController : Controller
    {
        private TeamComponent _teamComponent = new TeamComponent();
        private PlayerComponent _playerComponent = new PlayerComponent();



        // GET: Team
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
           
        }
       
        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            var list = _teamComponent.GetAll();
           
            return View(list);
        }  

        [HttpPost]
        [Authorize]
        public ActionResult GetAll(string search)
        {
            var teams = _teamComponent.GetAll();

            if (!String.IsNullOrEmpty(search))
            {
                var result = teams.Where(s => s.Name.ToLower().Contains(search.ToLower()) 
                                        || s.City.ToLower().Contains(search.ToLower()) 
                                        || s.Coach.ToLower().Contains(search.ToLower()));


                return View(result);
            }
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTeamPostMethod(TeamModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (string.IsNullOrEmpty(model.City))
            {
                ModelState.AddModelError("City", "City is required");
            }
            if (string.IsNullOrEmpty(model.Coach))
            {
                ModelState.AddModelError("Coach", "Coach is required");
            }
            if (ModelState.IsValid)
            {

                _teamComponent.Add(model);
                return RedirectToAction("GetAll");
            }
                
                return View("AddTeam",model);
            
                

            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditTeam(int id)
        {
            var matchingTeam = _teamComponent.GetById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingTeam);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTeamPostMethod(TeamModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (string.IsNullOrEmpty(model.City))
            {
                ModelState.AddModelError("City", "City is required");
            }
            if (string.IsNullOrEmpty(model.Coach))
            {
                ModelState.AddModelError("Coach", "Coach is required");
            }
            //var matchingTeam = _teamComponent.getTeamById(model.TeamId);
            //if (matchingTeam == null)
            //{
            //    return RedirectToAction("GetAll");
            //}
            if (ModelState.IsValid)
            {
                _teamComponent.Update(model);
                return RedirectToAction("GetAll");
            }
            

            return View("EditTeam",model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveTeam(int id)
        {
            var matchingTeam = _teamComponent.GetById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingTeam);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveTeamMethod(int TeamId)
        {
            var matchingTeam = _teamComponent.GetById(TeamId);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll");
            }

            _teamComponent.Delete(matchingTeam.TeamId);


            return RedirectToAction("GetAll");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AsignPlayer(int teamId)
        {
            var players = _playerComponent.GetAll();
            PlayerAsignModel playerAsignModel = new PlayerAsignModel()
            {
                teamId = teamId,
                playerModels = players
            };
            return View(playerAsignModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AsignPlayerPost(int teamId,int playerId)
        {
            if (teamId != null && playerId != null)
            {
                var player = _playerComponent.Get(playerId);

                player.Team.TeamId = teamId;

                _playerComponent.Update(player);
            }
            return RedirectToAction("GetAll");


        }

    }
}