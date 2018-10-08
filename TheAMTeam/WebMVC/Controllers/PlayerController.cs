using System;
using System.Linq;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interface;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;


namespace TheAMTeam.WebMVC.Controllers
{
    public class PlayerController : Controller
    {
        //--whitout UoWComponents
        //private static PlayerComponent _playerComp = new PlayerComponent();
        //private static TeamComponent _teamComp = new TeamComponent();

        private static IUnitOfWorkComponent _unitOfWorkComponent;

        //public PlayerController()
        //{
        //    _unitOfWorkComponent = new UnitOfWorkComponent(new UnitOfWorkRepository(new AppContext()));
        //}

        public PlayerController(IUnitOfWorkComponent unitOfWorkComponent)
        {
            _unitOfWorkComponent = unitOfWorkComponent;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //var players = _playerComp.GetAllPlayers().OrderByDescending(p => p.PlayerId);
            var players = _unitOfWorkComponent.Players.GetAllPlayers().OrderByDescending(p => p.PlayerId);

            return View(players);
        }

        [HttpGet]
        public ActionResult GetPlayerById(int id)
        {
            //var getPlayer = _playerComp.Get(id);
            var getPlayer = _unitOfWorkComponent.Players.Get(id);
            
            return View(getPlayer);
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            var viewModel = new PlayerModel();
            // ViewBag.Teams = _teamComp.GetAllTeams();
            ViewBag.Teams = _unitOfWorkComponent.Teams.GetAllTeams();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddPlayerPostMethod(PlayerModel player)
        {
            
            if (ModelState.IsValid)
            {
                //_playerComp.Add(player);
                _unitOfWorkComponent.Players.Add(player);
                return RedirectToAction("GetAll");
            }

            //ViewBag.Teams = _teamComp.GetAllTeams();          
            ViewBag.Teams = _unitOfWorkComponent.Teams.GetAllTeams();

            return View("AddPlayer", player);
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            //var matchingPlayer = _playerComp.Get(id);
            //ViewBag.Teams = _teamComp.GetAllTeams();
            var matchingPlayer = _unitOfWorkComponent.Players.Get(id);
            ViewBag.teams = _unitOfWorkComponent.Teams.GetAllTeams();
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }

            return View(matchingPlayer);
        }

        [HttpPost]
        public ActionResult EditPlayerPostMethod(PlayerModel model)
        {
            //var matchingPlayer = _playerComp.Get(model.PlayerId);
            //ViewBag.Teams = _teamComp.GetAllTeams();
            var matchingPlayer = _unitOfWorkComponent.Players.Get(model.PlayerId);
            ViewBag.Teams = _unitOfWorkComponent.Teams.GetAllTeams();
         
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }

            if (ModelState.IsValid)
            {
                //_playerComp.Update(model.PlayerId, model);
                _unitOfWorkComponent.Players.Update(model.PlayerId, model);
                return RedirectToAction("GetAll");
            }

            return View("EditPlayer", model);
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            //var matchingPlayer = _playerComp.Get(id);
            var matchingPlayer = _unitOfWorkComponent.Players.Get(id);

            if (matchingPlayer == null)
            {
                return RedirectToAction("GettAll");
            }

            return View(matchingPlayer);
        }

        [HttpPost]
        public ActionResult DeletePlayerPostMethod(int PlayerId)
        {
            //var matchingPlayer = _playerComp.Get(PlayerId);
            var matchingPlayer = _unitOfWorkComponent.Players.Get(PlayerId);

            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            //_playerComp.Delete(matchingPlayer.PlayerId);
            _unitOfWorkComponent.Players.Delete(matchingPlayer.PlayerId);

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult GetAll(string search)
        {
            //var players = _playerComp.GetAllPlayers();
            var players = _unitOfWorkComponent.Players.GetAllPlayers();

            if (!String.IsNullOrEmpty(search))
            {
                var result = players.Where(s => s.Name.Contains(search));


                return View(result);
            }
            return RedirectToAction("GetAll");
        }

        //Vote player of the year
       
        [HttpGet]
        public ActionResult Vote()
        {
            //var players = _playerComp.GetAllPlayers();
            var players = _unitOfWorkComponent.Players.GetAllPlayers();

            return View(players);
        }


        [HttpGet]
        public ActionResult VotePlayer(int id)
        {
            //var matchingPlayer = _playerComp.Get(id);
            var matchingPlayer = _unitOfWorkComponent.Players.Get(id);

            matchingPlayer.Vote.NumOfVotes++;

            //_playerComp.Update(id, matchingPlayer);    
            _unitOfWorkComponent.Players.Update(id, matchingPlayer);

            return RedirectToAction("Vote");
        }
    }
}