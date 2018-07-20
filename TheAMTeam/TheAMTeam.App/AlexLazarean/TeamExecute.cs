using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TheAMTeam.Data;
//using TheAMTeam.Data.Repositories;
using TheAMTeam.DataAccesLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.App.AlexLazarean
{
    public static class TeamExecute
    {
        public static readonly TeamRepository teamRepo = new TeamRepository();

        public static void PrintTeams(Team t)
        {
            Console.WriteLine(t.Name + " " + t.Id);
        }

        public static void Execute()
        {

            Team team = new Team
            {
                Id = 4,
                Name = "Fc Ceva",
                City = "Cluj",
                Coach = "X"
            };
     
            Console.WriteLine("Insert a number between 0 and 5");
            int caseSwitch = Int32.Parse(Console.ReadLine());
            while (caseSwitch != 0)
            {
                switch (caseSwitch)
                {
                    case 1:
                        foreach(Team t in teamRepo.GetAll())
                        {
                            PrintTeams(t);
                        }
                        //teamRepo.GetAll();
                        break;
                    case 2:
                        PrintTeams(teamRepo.GetById(2));
                        
                        break;
                    case 3:
                        teamRepo.Add(team);
                        break;
                    case 4:
                        //teamRepo.GetById(4);
                        teamRepo.Update(team);
                        break;
                    case 5:
                        Console.WriteLine(teamRepo.Delete(5));
                        break;

                }
                caseSwitch = Int32.Parse(Console.ReadLine());
            } 
        }
    }
}
