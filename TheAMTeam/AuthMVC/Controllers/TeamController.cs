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
        private PlayerComp _playerComponent = new PlayerComp();



        // GET: Team
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("Teams", new { page = 1 });
            //return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Teams(int page)
        {
            var list = _teamComponent.GetAllTeams();
            //foreach(var team in list)
            //{

            //    teams.Teams.Add(team);
            //}
            return View(list.Skip((page - 1) * 4).Take(4));
            //var result = (from team in list
            //              orderby team.TeamId descending
            //              select team).Skip((page - 1) * 6).Take(6);
            //return View(result);

        }
        [HttpPost]
        [Authorize]
        public ActionResult Teams(string search)
        {
            var teams = _teamComponent.GetAllTeams();

            if (!String.IsNullOrEmpty(search))
            {
                var result = teams.Where(s => s.Name.Contains(search));


                return View(result);
            }
            return RedirectToAction("Teams", new { page = 1 });
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
            if (ModelState.IsValid)
            {
                _teamComponent.AddTeam(model);
            }

            return RedirectToAction("Teams", new { page = 1 });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditTeam(int id)
        {
            var matchingTeam = _teamComponent.getTeamById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("Teams", new { page = 1 });
            }
            return View(matchingTeam);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTeamPostMethod(TeamModel model)
        {
            var matchingTeam = _teamComponent.getTeamById(model.TeamId);
            if (matchingTeam == null)
            {
                return RedirectToAction("Teams", new { page = 1 });
            }

            _teamComponent.UpdateTeam(model);
            

            return RedirectToAction("Teams", new { page = 1 });
        }
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveTeam(int id)
        {
            var matchingTeam = _teamComponent.getTeamById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("Teams", new { page = 1 });
            }
            return View(matchingTeam);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveTeamMethod(int TeamId)
        {
            var matchingTeam = _teamComponent.getTeamById(TeamId);
            if (matchingTeam == null)
            {
                return RedirectToAction("Teams", new { page = 1 });
            }

            _teamComponent.DeleteTeam(matchingTeam.TeamId);


            return RedirectToAction("Teams", new { page = 1 });
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult AsignPlayerPost(int teamId,int playerId)
        {
            if (teamId != null && playerId != null)
            {
                var player = _playerComponent.Get(playerId);

                player.TeamId = teamId;

                _playerComponent.Update(playerId,player);
            }
            return RedirectToAction("Teams", new { page = 1 });


        }

    }
}