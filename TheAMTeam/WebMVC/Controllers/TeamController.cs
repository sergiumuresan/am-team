using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;
using TheAMTeam.WebMVC.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class TeamController : Controller
    {
        private TeamComponent _teamComponent = new TeamComponent();
        private PlayerComp _playerComponent = new PlayerComp();
        // GET: Team
        public ActionResult Index()
        {
            return RedirectToAction("GetAll", new { page = 1 });
        }
        [HttpGet]
        public ActionResult GetAll(int page)
        {
            var list = _teamComponent.GetAllTeams();
            //foreach(var team in list)
            //{

            //    teams.Teams.Add(team);
            //}
            return View(list.Skip((page - 1) * 5).Take(5));
            //var result = (from team in list
            //              orderby team.TeamId descending
            //              select team).Skip((page - 1) * 6).Take(6);
            //return View(result);

        }
        [HttpPost]
        public ActionResult GetAll(string search)
        {
            var teams = _teamComponent.GetAllTeams();

            if (!String.IsNullOrEmpty(search))
            {
                var result = teams.Where(s => s.Name.ToLower().Contains(search.ToLower())
                                        || s.City.ToLower().Contains(search.ToLower())
                                        || s.Coach.ToLower().Contains(search.ToLower())
                
                                         );


                return View(result.Take(5));
            }
            return RedirectToAction("GetAll", new { page = 1 });
        }

        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
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
                _teamComponent.AddTeam(model);
                return RedirectToAction("GetAll", new { page = 1 });
            }
            return View("AddTeam", model);

        }

        public ActionResult EditTeam(int id)
        {
            var matchingTeam = _teamComponent.getTeamById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll", new { page = 1 });
            }
            return View(matchingTeam);
        }

        [HttpPost]
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
            if (ModelState.IsValid)
            {
                _teamComponent.UpdateTeam(model);
                return RedirectToAction("GetAll", new { page = 1 });
            }
            return View("EditTeam", model);

        }
        public ActionResult RemoveTeam(int id)
        {
            var matchingTeam = _teamComponent.getTeamById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll", new { page = 1 });
            }
            return View(matchingTeam);
        }
        [HttpPost]
        public ActionResult RemoveTeamMethod(int TeamId)
        {
            var matchingTeam = _teamComponent.getTeamById(TeamId);
            if (matchingTeam == null)
            {
                return RedirectToAction("GetAll", new { page = 1 });
            }

            _teamComponent.DeleteTeam(matchingTeam.TeamId);


            return RedirectToAction("GetAll", new { page = 1 });
        }

        public ActionResult AsignPlayer(int teamId)
        {
            var players = _playerComponent.GetAllPlayers();
            PlayerAsignModel playerAsignModel = new PlayerAsignModel()
            {
                teamId = teamId,
                playerModels = players
            };
            return View(playerAsignModel);
        }

        [HttpPost]
        public ActionResult AsignPlayerPost(int teamId,int playerId)
        {
            if (teamId != null && playerId != null)
            {
                var player = _playerComponent.Get(playerId);

                player.TeamId = teamId;

                _playerComponent.Update(playerId,player);
            }
            return RedirectToAction("GetAll", new { page = 1 });


        }

    }
}