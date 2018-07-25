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
        
        //public List<TestEntityModel> GetById()
        //{
        //  //  var getResult = _testComponent.Get();

        //  //  return getResult;
        //}
    }
}
//using Internship.Data.Entities;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace IntenshipWebApi.Controllers
//{
//    public class OfferController : ApiController
//    {
//        public IHttpActionResult GetOffers()
//        {
//            using (var context = new Internship.Data.Contexts.AppContext(ConfigurationManager.ConnectionStrings["InternshipAppConnection"].ConnectionString))
//            {
//                try
//                {
//                    var offers = (from u in context.Offers
//                                  select u).ToList();
//                    return Ok(offers);
//                }
//                catch (Exception ex)
//                {
//                    //log ex..
//                    return InternalServerError(new Exception("oops something is wrong"));
//                }

//            }
//        }

//        [HttpPut]
//        public IHttpActionResult Put([FromBody] Offer offer)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(offer.OfferName))
//                {
//                    return this.BadRequest("OfferName is mandatory");
//                }
//                using (var context = new Internship.Data.Contexts.AppContext(ConfigurationManager.ConnectionStrings["InternshipAppConnection"].ConnectionString))
//                {
//                    var dbuser = (from u in context.Offers
//                                  where u.OfferId == offer.OfferId
//                                  select u).FirstOrDefault();
//                    if (dbuser == null)
//                    {
//                        return this.NotFound();
//                    }

//                    dbuser.OfferName = offer.OfferName;
//                    context.SaveChanges();
//                }
//                return Ok(offer);
//            }
//            catch (Exception ex)
//            {

//                return InternalServerError(new Exception("oops something is wrong"));
//            }
//        }

//        [HttpPost]
//        public IHttpActionResult Post([FromBody] Offer offer)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(offer.OfferName))
//                {
//                    return this.BadRequest("OfferName is mandatory");
//                }

//                using (var context = new Internship.Data.Contexts.AppContext(ConfigurationManager.ConnectionStrings["InternshipAppConnection"].ConnectionString))
//                {

//                    context.Offers.Add(offer);
//                    context.SaveChanges();
//                }
//                return Ok(offer);
//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(new Exception("oops something is wrong"));
//            }
//        }

//        [HttpDelete]
//        public IHttpActionResult Delete([FromBody] Offer offer)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(offer.OfferName))
//                {
//                    return this.BadRequest("OfferName is mandatory");
//                }

//                using (var context = new Internship.Data.Contexts.AppContext(ConfigurationManager.ConnectionStrings["InternshipAppConnection"].ConnectionString))
//                {
//                    var dbuser = (from u in context.Offers
//                                  where u.OfferId == offer.OfferId
//                                  select u).FirstOrDefault();
//                    if (dbuser == null)
//                    {
//                        return this.NotFound();
//                    }

//                    context.Offers.Remove(dbuser);
//                    context.SaveChanges();
//                }
//                return Ok(offer);
//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(new Exception("oops something is wrong"));
//            }
//        }
//    }
//}