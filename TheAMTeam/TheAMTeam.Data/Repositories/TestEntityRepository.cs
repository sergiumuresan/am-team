using System;

namespace TheAMTeam.Data.Repositories
{
    public class TestEntityRepository
    {
        public TestEntity Create(TestEntity testEntity)
        {
            TestEntity dbTestEntity;
            try
            {
                using (var context = new AMTeamEntities())
                {
                    //Create a new entry in table, and get the new object
                    dbTestEntity = context.TestEntities.Add(testEntity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return dbTestEntity;
        }
    }
}
