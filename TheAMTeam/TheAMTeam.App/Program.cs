using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App
{
    internal class Program
    {
        public static MatchRepository _matchRepository = new MatchRepository();

        static void Main(string[] args)
        {
            //Example.Example.Execute();
            IosuaSipos.MatchTests.Execute();
        }
    }
}
