using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class PlayersRepository
    {
        private object vote;

        public Player Create(Player playerEntity)
        {
            Player dbPlayer;
            try
            {
                using (var context = new AppContext())
                {
                    //Create a new entry in table, and get the new object

                    dbPlayer = context.Players.Add(playerEntity);
                    Vote vote = new Vote
                    {
                        Id = dbPlayer.PlayerId,
                        NumOfVotes = 0
                    };

                    dbPlayer.Vote = vote;
                    context.SaveChanges();
                    return dbPlayer;
                }
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
                using (var context = new AppContext())
                {
                    dbPlayer = context.Players.Include("Team").Include("Vote").SingleOrDefault(c => c.PlayerId == id);
                    context.SaveChanges();
                }
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
                using (var context = new AppContext())
                {
                    Player dbPlayer = context.Players.Include("Team").Include("Vote").SingleOrDefault(c => c.PlayerId == playerId);


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


                    context.SaveChanges();

                    return dbPlayer;
                }
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
                using (var context = new AppContext())
                {
                    if (context.Players.Find(id) != null)
                    {
                        Player dbPlayer = context.Players.SingleOrDefault(c => c.PlayerId == id);
                        context.Votes.Remove(dbPlayer.Vote);
                        context.Players.Remove(dbPlayer);                        
                        context.SaveChanges();
                        Console.WriteLine("Line {0} deleted!", id);
                        return true;
                    }
                    Console.WriteLine("Line {0} already deleted!", id);
                    return false;
                }
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
                using (var context = new AppContext())
                {
                    var result = context.Players.Include("Team").Include("Vote").ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw ex;
            }
        }
    }

}
