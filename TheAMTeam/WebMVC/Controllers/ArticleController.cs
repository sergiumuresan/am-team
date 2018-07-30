using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleComponent articleComponent = new ArticleComponent();
        // GET: Article
        public ActionResult getAll()
        {
            var getAll = articleComponent.GetAll();
            
            return View(getAll);
        }

        public ActionResult getById(int id)
        {
            var getById = articleComponent.GetById(id);
            return View(getById);
        }

       public ActionResult Add()
        {
            return View();
        } 
       public ActionResult AddNew(ArticleBussinessModel fullArticle)
        {
            fullArticle.PublishedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var add = articleComponent.Add(fullArticle);
            }
            return RedirectToAction("GetAll");

        }

        public ActionResult Delete(int id)
        {
            var toDelete = articleComponent.GetById(id);
            var deleted = toDelete != null ? articleComponent.Delete(toDelete.ArticleId) : false;

            return RedirectToAction("GetAll");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult EditNew(ArticleBussinessModel editedArticle)
        {
            //var article = articleComponent.GetById(editedArticle.ArticleId);
            editedArticle.PublishedDate = DateTime.Now;
            
            if(editedArticle != null)
            {
                articleComponent.Update(editedArticle);
                
            }
            return RedirectToAction("GetAll");
        }

       
    }
}