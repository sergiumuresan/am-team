using AuthMVC;
using AuthMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;
using TheAMTeam.WebMVC.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class PlayerController : Controller
    {
        private PlayerComponent _playerComponent = new PlayerComponent();
        private TeamComponent _teamComponent = new TeamComponent();
        private NationalityComponent _nationalityComponent = new NationalityComponent();



        // GET: Player
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
           
        }
       
        [HttpGet]
        [Authorize]
        public ActionResult GetAll()
        {
            var list = _playerComponent.GetAll();
           
            return View(list);
        }  

        [HttpPost]
        [Authorize]
        public ActionResult GetAll(string search)
        {
            var players = _playerComponent.GetAll();

            if (!String.IsNullOrEmpty(search))
            {
                var result = players.Where(s => s.Name.ToLower().Contains(search.ToLower()) 
                                        || s.NameAlias.ToLower().Contains(search.ToLower()) 
                                        || s.Team.Name.ToLower().Contains(search.ToLower())
                                        || s.Nationality.Name.ToLower().Contains(search.ToLower())
                                        );


                return View(result);
            }
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult AddPlayer()
        {
            var teams = _teamComponent.GetAll();
            var nationalities = _nationalityComponent.GetAll();
            var player = new PlayerBusinessModel();
            PlayerAddModel add = new PlayerAddModel(teams, nationalities,player);
            return View(add);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult AddPlayerPostMethod(PlayerBusinessModel model)
        {
            model.Nationality = _nationalityComponent.GetById(model.NationalityId);
            model.Team = _teamComponent.GetById(model.TeamId);
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            
            if (ModelState.IsValid)
            {

                _playerComponent.Add(model);
                return RedirectToAction("GetAll");
            }
                
                return View("AddPlayer",model);
            
                

            
        }

        [Authorize(Roles = "Admin,Staff")]
        public ActionResult EditPlayer(int playerId)
        {
            var matchingPlayer = _playerComponent.Get(playerId);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            var teams = _teamComponent.GetAll();
            var nationalities = _nationalityComponent.GetAll();
            PlayerAddModel player = new PlayerAddModel(teams, nationalities, matchingPlayer);

            return View(player);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult EditPlayerPostMethod(PlayerBusinessModel model)
        {
            model.Nationality = _nationalityComponent.GetById(model.NationalityId);
            model.Team = _teamComponent.GetById(model.TeamId);
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            
            //var matchingTeam = _teamComponent.getTeamById(model.TeamId);
            //if (matchingTeam == null)
            //{
            //    return RedirectToAction("GetAll");
            //}
            if (ModelState.IsValid)
            {
                _playerComponent.Update(model);
                return RedirectToAction("GetAll");
            }
            

            return View("EditPlayer",model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult RemovePlayer(int id)
        {
            var matchingPlayer = _playerComponent.Get(id);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingPlayer);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult RemovePlayerMethod(int playerId)
        {
            var matchingPlayer = _playerComponent.Get(playerId);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }

            _playerComponent.Delete(matchingPlayer.PlayerId);


            return RedirectToAction("GetAll");
        }

        


    }
}