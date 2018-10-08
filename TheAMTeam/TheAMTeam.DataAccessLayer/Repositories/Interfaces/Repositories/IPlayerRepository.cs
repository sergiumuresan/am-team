using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player Create(Player playerEntity);
        Player GetById(int id);
        Player Update(int playerId, Player newPlayer);
        bool Delete(int id);
        List<Player> GetAll();
    }
}
