using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Data;
using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App.TeodorDumitriu
{
    public static class MainTask
    {
        private static readonly PlayersRepository _playersRepository = new PlayersRepository();
        public static void Execute()
        {
            int[] i = { 1, 0, 1, 4, 5, 3, 0 };

            foreach (var item in i)
            {
                if (item == 1) PrintAll();
                else if (item == 2) GetAnyById(2);
                else if (item == 3) _playersRepository.Create(new Player());
                //else if (item == 4) _playersRepository.Update();
                // else if (item == 5) _playersRepository.Delete(5);               
            }
        }

        private static void PrintAll()
        {
            foreach (Player player in _playersRepository.GetAll())
            {
                Console.WriteLine(player.Name);
            }
        }

        private static Player GetAnyById(int id)
        {
            return _playersRepository.GetById(id);
        }



        private static void Delete5thItem()
        {


        }

        //private static TestEntity SaveTestEntity(TestEntity testEntity)
        //{
        //    var savedTestEntity = _testEntityRepository.Create(testEntity);

        //    return savedTestEntity;
        //}
    }
}
