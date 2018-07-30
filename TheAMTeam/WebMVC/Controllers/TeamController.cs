﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class TeamController : Controller
    {
        private TeamComponent _teamComponent = new TeamComponent();
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Teams()


        {
            var list = _teamComponent.GetAllTeams();
            //foreach(var team in list)
            //{

            //    teams.Teams.Add(team);
            //}
            return View(list);
        }

        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeamPostMethod(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                _teamComponent.AddTeam(model);
            }

            return RedirectToAction("Teams");
        }

        public ActionResult EditTeam(int id)
        {
            var matchingTeam = _teamComponent.getTeamById(id);
            if (matchingTeam == null)
            {
                return RedirectToAction("Teams");
            }
            return View(matchingTeam);
        }

        [HttpPost]
        public ActionResult EditTeamPostMethod(TeamModel model)
        {
            var matchingIntern = _teamComponent.getTeamById(model.TeamId);
            if (matchingIntern == null)
            {
                return RedirectToAction("Teams");
            }

            _teamComponent.UpdateTeam(model);
            

            return RedirectToAction("Teams");
        }

    }
}