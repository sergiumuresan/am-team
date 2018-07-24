using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class TestComponent
    {
        private readonly TestEntityRepository _testEntityRepository;

        public TestComponent()
        {
            _testEntityRepository = new TestEntityRepository();
        }

        public List<TestEntityModel> GetAllTests()
        {
            var result = _testEntityRepository.GetAll();

            var returnList = new List<TestEntityModel>();

            foreach (var item in result)
            {
                returnList.Add(new TestEntityModel
                {
                    Id = item.Id,
                    Message = item.Message
                }); 
            }

            return returnList;

        }
    }
}