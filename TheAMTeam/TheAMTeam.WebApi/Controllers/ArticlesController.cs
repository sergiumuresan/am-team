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
        public ArticleModel Create([FromBody] ArticleModel myArticle)
        {
            var result = _articleComponent.Add(myArticle);

            return result;
        }

        [System.Web.Http.HttpGet]
        public ArticleModel Read(int id)
        {
            var result = _articleComponent.GetById(id);

            return result;
        }

        [System.Web.Http.HttpGet]
        public List<ArticleModel> GetAll()
        {
            var result = _articleComponent.GetAll();

            return result;
        }

        [System.Web.Http.HttpPut]
        public ArticleModel Update([FromBody] ArticleModel newArticleModel)
        {
            var result = _articleComponent.Update(newArticleModel);

            return result;
        }

        [System.Web.Http.HttpDelete]
        public bool Delete(int id)
        {
            var result = _articleComponent.Delete(id);

            return result;
        }

    }
}
