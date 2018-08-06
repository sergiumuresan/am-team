using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interfaces
{
    public interface IPlayerComp
    {
        PlayerBusinessModel Add(PlayerBusinessModel model);
        List<PlayerBusinessModel> GetAllPlayers();
        PlayerBusinessModel Get(int id);
        PlayerBusinessModel Update(int playerId, PlayerBusinessModel model);
        bool Delete(int id);

    }
}
