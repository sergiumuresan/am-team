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
        private static PlayerComp playerComp = new PlayerComp();

        [HttpGet]
        public ActionResult GetAll()
        {
            var players = playerComp.GetAllPlayers();
            return View(players);
        }

        [HttpGet]
        public ActionResult GetPlayerById(int id)
        {
            var getPlayer = playerComp.Get(id);
            return View(getPlayer);
        }

        [HttpPost]
        public ActionResult AddPlayer(PlayerBusinessModel player)
        {
            if(ModelState.IsValid)
            {
                playerComp.Add(player);
            }
            return RedirectToAction("GetAll");
        }

        [HttpPut]
        public ActionResult EditPlayer(PlayerBusinessModel model)
        {
            var matchingPlayer = playerComp.Get(model.PlayerId);
            if(matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            matchingPlayer.Name = model.Name;
            matchingPlayer.TeamId = model.TeamId;
            matchingPlayer.TshirtNO = model.TshirtNO;
            matchingPlayer.BirthDate = model.BirthDate;
            matchingPlayer.NameAlias = model.NameAlias;
            matchingPlayer.NationalityId = model.NationalityId;

            return RedirectToAction("GetAll");
        }

        [HttpDelete]
        public ActionResult DeletePlayer(int id)
        {
            var deletePlayer = playerComp.Delete(id);
            if(deletePlayer == null)
            {
                return 
            }
            return RedirectToAction("GetAll");
        }
    }   
}