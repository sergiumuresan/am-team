using TheAMTeam.Data;
using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App.Example
{
    public static class Example
    {
        private static readonly TestEntityRepository _testEntityRepository = new TestEntityRepository();
        public static void Execute()
        {

            var testEntity = CreateTestEntity();
            var savedTestEntity = SaveTestEntity(testEntity);
        }

        private static TestEntity CreateTestEntity()
        {
            var testEntity = new TestEntity
            {
                Message = "I am a new Test Entry."
            };

            return testEntity;
        }

        private static TestEntity SaveTestEntity(TestEntity testEntity)
        {
            var savedTestEntity = _testEntityRepository.Create(testEntity);

            return savedTestEntity;
        }
    }
}
