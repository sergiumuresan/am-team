using System;
using TheAMTeam.DataAccessLayer.Entities;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class TestEntityRepository
    {
        public TestEntity Create(TestEntity testEntity)
        {
            TestEntity dbTestEntity;
            try
            {
                using (var context = new AppContext())
                {
                    //Create a new entry in table, and get the new object
                    dbTestEntity = context.TestEntities.Add(testEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                //todo exeption handling
                throw;
            }

            return dbTestEntity;
        }
    }
}
