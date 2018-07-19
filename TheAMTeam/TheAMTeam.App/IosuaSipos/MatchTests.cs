using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Data;
using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App.IosuaSipos
{
    class MatchTests
    {
        private static readonly MatchRepository _testMatchRepository = new MatchRepository();

        public static void PrintMatch(Match m)
        {
            Console.WriteLine(m.FirstTeamId + " / " + m.SecondTeamId);
        }
        public static void Execute()
        {
            var testMatch = createTestMatch();
            var savedTestMatch = SaveTestMathc(testMatch);
           
        }
        private static object createTestMatch()
        {
            //DateTime date1 = new DateTime(2018, 3, 2);

            Match match = new Match()
            {
                FirstTeamId = 1,
                SecondTeamId = 2,
                FirstTeamScore = 2,
                SecondTeamScore = 1,
                Match_date = DateTime.Now,
                CompId = 1
            };

            Console.WriteLine("Please enter a number between 0 and 5:");
            int number = Int32.Parse(Console.ReadLine());
            while (number != 0 || number < 6)
            {
                switch(number)
                {
                    case 1:
                        foreach (Match m in _testMatchRepository.getAll())
                            {
                                PrintMatch(m);
                            }
                        break;
                    case 2:
                        PrintMatch(_testMatchRepository.GetById(1));
                        break;
                    case 3:
                        PrintMatch(_testMatchRepository.Add(match));
                        break;
                    case 4:
                        match = _testMatchRepository.GetById(4);
                        match.SecondTeamScore = 3;
                        //PrintMatch(_testMatchRepository.Update(match));
                        _testMatchRepository.Update(match);
                        break;
                    case 5:
                        _testMatchRepository.Delete(5);
                        break;
                    


                }
                number = Int32.Parse(Console.ReadLine());
            }

            throw new NotImplementedException();
        }

        private static object SaveTestMathc(object testMatch)
        {
            throw new NotImplementedException();
        }

    }

}
