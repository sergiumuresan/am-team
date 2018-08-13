using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;


namespace TheAMTeam.WebMVC.Controllers
{
    public class PlayerController : Controller
    {
        private static PlayerComp _playerComp = new PlayerComp();
        private static TeamComponent _teamComp = new TeamComponent();

        [HttpGet]
        public ActionResult GetAll()
        {
            var players = _playerComp.GetAllPlayers().OrderByDescending(p => p.PlayerId);

            return View(players);
        }

        [HttpGet]
        public ActionResult GetPlayerById(int id)
        {
            var getPlayer = _playerComp.Get(id);
            return View(getPlayer);
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            var viewModel = new PlayerBusinessModel();
            ViewBag.Teams = _teamComp.GetAllTeams();


            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddPlayerPostMethod(PlayerBusinessModel player)
        {
            
            if (ModelState.IsValid)
            {
                _playerComp.Add(player);
                return RedirectToAction("GetAll");
            }
            
            ViewBag.Teams = _teamComp.GetAllTeams();

            return View("AddPlayer", player);
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
            ViewBag.Teams = _teamComp.GetAllTeams();
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }

            return View(matchingPlayer);
        }

        [HttpPost]
        public ActionResult EditPlayerPostMethod(PlayerBusinessModel model)
        {
            var matchingPlayer = _playerComp.Get(model.PlayerId);
            ViewBag.Teams = _teamComp.GetAllTeams();
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }

            if (ModelState.IsValid)
            {
                _playerComp.Update(model.PlayerId, model);
                return RedirectToAction("GetAll");
            }

            return View("EditPlayer", model);
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GettAll");
            }

            return View(matchingPlayer);
        }

        [HttpPost]
        public ActionResult DeletePlayerPostMethod(int PlayerId)
        {
            var matchingPlayer = _playerComp.Get(PlayerId);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            _playerComp.Delete(matchingPlayer.PlayerId);

            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult GetAll(string search)
        {
            var players = _playerComp.GetAllPlayers();

            if (!String.IsNullOrEmpty(search))
            {
                var result = players.Where(s => s.Name.Contains(search));


                return View(result);
            }
            return RedirectToAction("GetAll");
        }

        //Vote player of the year
       
        public ActionResult Vote()
        {
            var players = _playerComp.GetAllPlayers();

            return View(players);
        }

        public ActionResult ValidateVote(int id)
        {
            var player = _playerComp.Get(id);
            return View(player);
        }
      

        [HttpPost]
        public ActionResult VotePlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);

            matchingPlayer.Vote.NumOfVotes++;

             _playerComp.Update(matchingPlayer.PlayerId, matchingPlayer);

            var players

            return RedirectToAction("Vote", );
        }
    }
}