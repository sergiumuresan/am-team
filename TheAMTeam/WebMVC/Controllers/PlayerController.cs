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

        [HttpGet]
        public ActionResult GetAll()
        {
            var players = _playerComp.GetAllPlayers();
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
            return View();
        }


        [HttpPost]
        public ActionResult AddPlayerPostMethod(PlayerBusinessModel player)
        {

            if(ModelState.IsValid)
            {
                _playerComp.Add(player);
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
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
            if(matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            _playerComp.Update(model.PlayerId, model);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
            if(matchingPlayer == null)
            {
                return RedirectToAction("GettAll");
            }

            return View(matchingPlayer);
        }

        [HttpPost]
        public ActionResult DeletePlayerPostMethod(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GettAll");
            }
            _playerComp.Delete(matchingPlayer.PlayerId);

            return View(matchingPlayer);
        }
    }   
}