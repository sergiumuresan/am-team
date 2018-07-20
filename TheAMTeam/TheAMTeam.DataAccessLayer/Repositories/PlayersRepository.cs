using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class PlayersRepository
    {
        public Player Create(Player playerEntity)
        {
            Player dbPlayer;
            try
            {
                using (var context = new AppContext())
                {
                    //Create a new entry in table, and get the new object
                    dbPlayer = context.Players.Add(playerEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbPlayer;
        }

        public Player GetById(int id)
        {
            Player dbPlayer;
            try
            {
                using (var context = new AppContext())
                {
                    dbPlayer = context.Players.Find(id);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw;
            }

            return dbPlayer;
        }

        public Player Update(Player newPlayer)
        {
            try
            {
                using (var context = new AppContext())
                {
                    int id = newPlayer.PlayerId;
                    Player dbPlayer = context.Players.Find(id);


                    dbPlayer.BirthDate = newPlayer.BirthDate;
                    dbPlayer.Name = newPlayer.Name;
                    dbPlayer.NameAlias = newPlayer.NameAlias;
                    //dbPlayer.Nationality = newPlayer.Nationality;
                    dbPlayer.NationalityId = newPlayer.NationalityId;
                    dbPlayer.PlayerId = newPlayer.PlayerId;
                    //dbPlayer.Team = newPlayer.Team;
                    //dbPlayer.Team1 = newPlayer.Team1;
                    dbPlayer.TshirtNO = newPlayer.TshirtNO;

                    context.SaveChanges();

                    return dbPlayer;
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw;
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
                        Player dbPlayer = context.Players.Find(id);
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
                throw;
            }
        }

        public List<Player> GetAll()
        {
            try
            {
                using (var context = new AppContext())
                {
                    var result = context.Players.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //todo exeption handling
                throw;
            }
        }
    }

}
