using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interface.Components
{
    public interface IPlayerComponent
    {
        PlayerModel Add(PlayerModel model);
        List<PlayerModel> GetAllPlayers();
        PlayerModel Get(int id);
        PlayerModel Update(int playerId, PlayerModel model);
        bool Delete(int id);
    }
}
