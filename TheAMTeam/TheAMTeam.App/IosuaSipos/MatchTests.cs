using System;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.App.IosuaSipos
{
    class MatchTests
    {
        private static readonly MatchRepository _testMatchRepository = new MatchRepository();

        public static void PrintMatch(Match m)
        {
            Console.WriteLine($"{m.FirstTeamId}/{m.SecondTeamId}");

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
                MatchDate = DateTime.Now,
                CompetitionId = 1
            };

            Console.WriteLine("Please enter a number between 0 and 5:");
            int number = Int32.Parse(Console.ReadLine());
            while (number != 0 || number < 6)
            {
                switch(number)
                {
                    case 1:
                        var allMatches = _testMatchRepository.getAll();
                        foreach (Match m in allMatches)
                            {
                                PrintMatch(m);
                            }
                        break;
                    case 2:
                        var result = _testMatchRepository.GetById(1);
                        PrintMatch(result);
                        break;
                    case 3:
                        _testMatchRepository.Add(match);
                        break;
                    case 4:
                        match = _testMatchRepository.GetById(2);
                        match.SecondTeamScore = 3;
                        var updateResult = _testMatchRepository.Update(match);
                        PrintMatch(updateResult);
                        break;
                    case 5:
                        var deleteResult = _testMatchRepository.Delete(5);
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
