
using System.Linq;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interfaces.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class PlayerController : Controller
    {
        private static PlayerComp _playerComp = new PlayerComp();
        private static TeamComponent _teamComp = new TeamComponent();

        //private static IUnitOfWorkComponent _unitOfWork;

        public PlayerController() {

        }





        [HttpGet]
        public ActionResult GetAll()
        {
            var players1 = _playerComp.GetAllPlayers().OrderByDescending(p => p.PlayerId);
            //var players = _unitOfWork.Players.GetAllPlayers();

            return View(players1);
        }

        private ActionResult  GetAllPlayers()
        {
            var players =  _playerComp.GetAllPlayers();
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
            var viewModel = new PlayerBusinessModel
            {
                Teams = _teamComp.GetAllTeams()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddPlayerPostMethod(PlayerBusinessModel player)
        {

            if (ModelState.IsValid)
            {
            }
            _playerComp.Add(player);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            var player = _playerComp.Get(id);

            if (player == null)
                return HttpNotFound();

            PlayerBusinessModel matchingPlayer = new PlayerBusinessModel
            {
                PlayerId = player.PlayerId,
                TshirtNO = player.TshirtNO,
                BirthDate = player.BirthDate,
                Name = player.Name,
                NameAlias = player.NameAlias,
                Teams = _teamComp.GetAllTeams(),
                //Teams = _unitOfWork.Teams.GetAllTeams(),
                TeamId = player.TeamId

            };
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
            //var matchingPlayer = _unitOfWork.Players.Get(model.PlayerId);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            _playerComp.Update(model.PlayerId, model);
            //_unitOfWork.Players.Update(model.PlayerId, model);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            var matchingPlayer = _playerComp.Get(id);
            //var matchingPlayer = _unitOfWork.Players.Get(id);
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
            //var matchingPlayer = _unitOfWork.Players.Get(PlayerId);
            if (matchingPlayer == null)
            {
                return RedirectToAction("GetAll");
            }
            _playerComp.Delete(matchingPlayer.PlayerId);
            //_unitOfWork.Players.Delete(matchingPlayer.PlayerId);

            return RedirectToAction("GetAll");
        }
    }
}