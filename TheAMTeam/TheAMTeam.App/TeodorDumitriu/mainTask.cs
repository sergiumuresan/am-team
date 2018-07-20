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
            int[] i = { 1, 2, 3, 4, 5, 0 };

            var player = new Player();
            player.NationalityId = 1;
            player.Name = "Teo";
            
            

            foreach (var item in i)
            {
                if (item == 1) PrintAll();
                else if (item == 2) GetAnyById(22);
                //else if (item == 3) _playersRepository.Create(player);
                //else if (item == 4) _playersRepository.Update(player);
                else if (item == 5) _playersRepository.Delete(29);    
            }
        }

        private static void PrintAll()
        {
            foreach (Player player in _playersRepository.GetAll())
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine("");
        }

        private static void GetAnyById(int id)
        {
            var x = _playersRepository.GetById(id);
            Console.WriteLine(x.Name);
            Console.WriteLine("");
        }


        //private static TestEntity SaveTestEntity(TestEntity testEntity)
        //{
        //    var savedTestEntity = _testEntityRepository.Create(testEntity);

        //    return savedTestEntity;
        //}
    }
}
