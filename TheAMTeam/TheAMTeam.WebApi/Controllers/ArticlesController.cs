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
using TheAMTeam.Business.Utils;

namespace TheAMTeam.WebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        private ArticleComponent _articleComponent = new ArticleComponent();

        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/articles")]
        public HttpResponseMessage Create([FromBody] ArticleBussinessModel myArticle)
        {
            try
            {
                var result = _articleComponent.Add(myArticle);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [System.Web.Http.Route("api/articles/{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Read(int id)
        {
            try
            {
                var result = _articleComponent.GetById(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [System.Web.Http.Route("api/articles")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var result = _articleComponent.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [System.Web.Http.Route("api/articles")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage Update([FromBody] ArticleBussinessModel newArticleModel)
        {
            try
            {
                var result = _articleComponent.Update(newArticleModel);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [System.Web.Http.Route("api/articles")]
        [System.Web.Http.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = _articleComponent.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
