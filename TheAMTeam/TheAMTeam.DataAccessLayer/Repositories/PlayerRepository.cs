using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IAppContext _context;

        public PlayerRepository(IAppContext context)
        {
            _context = context;
        }

        public Player Create(Player playerEntity)
        {
            Player dbPlayer;
            try
            {
                dbPlayer = _context.Players.Add(playerEntity);
                Vote vote = new Vote
                {
                    Id = dbPlayer.PlayerId,
                    NumOfVotes = 0
                };

                dbPlayer.Vote = vote;
                _context.SaveChanges();

                return dbPlayer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public Player GetById(int id)
        {
            Player dbPlayer;
            try
            {
                dbPlayer = _context.Players
                    .Include("Team")
                    .Include("Vote")
                    .SingleOrDefault(c => c.PlayerId == id);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }

            return dbPlayer;
        }

        public Player Update(int playerId,Player newPlayer)
        {
            try
            {
                Player dbPlayer = _context.Players
                    .Include("Team")
                    .Include("Vote")
                    .SingleOrDefault(c => c.PlayerId == playerId);

                dbPlayer.BirthDate = newPlayer.BirthDate;
                dbPlayer.Name = newPlayer.Name;
                dbPlayer.NameAlias = newPlayer.NameAlias;
                //dbPlayer.Nationality = newPlayer.Nationality;
                dbPlayer.NationalityId = newPlayer.NationalityId;
                //dbPlayer.PlayerId = newPlayer.PlayerId;
                //dbPlayer.Team = newPlayer.Team;
                //dbPlayer.Team1 = newPlayer.Team1;
                dbPlayer.TeamId = newPlayer.TeamId;
                dbPlayer.TshirtNO = newPlayer.TshirtNO;
                dbPlayer.Vote.Id = newPlayer.Vote.Id;
                dbPlayer.Vote.NumOfVotes = newPlayer.Vote.NumOfVotes;

                _context.SaveChanges();

                return dbPlayer;
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (_context.Players.Find(id) != null)
                {
                    Player dbPlayer = _context
                        .Players.SingleOrDefault(c => c.PlayerId == id);

                    _context.Votes.Remove(dbPlayer.Vote);
                    _context.Players.Remove(dbPlayer);                        
                    _context.SaveChanges();
                    Console.WriteLine("Line {0} deleted!", id);
                    return true;
                }
                Console.WriteLine("Line {0} already deleted!", id);
                return false;
                
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }
        }

        public List<Player> GetAll()
        {
            try
            {
                var result = _context.Players
                    .Include("Team")
                    .Include("Vote")
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }
        }
    }

}
