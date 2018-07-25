using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebApi.Controllers
{
    public class TestController : ApiController
    {
        private TestComponent _testComponent = new TestComponent();
    
        // GET: TestEntity
        public List<TestEntityModel> Get()
        {
            var getResult = _testComponent.GetAllTests();

            return getResult;
        }


    }
}