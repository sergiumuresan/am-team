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
        private CategoryComponent categoryComponent = new CategoryComponent();
        // GET: Article
        public ActionResult getAll()
        {
            var getAll = articleComponent.GetAll();
            
            return View(getAll);
        }

        public  ActionResult getAllCategoryId()
        {
            var getAllCategory = categoryComponent.GetAll();
            return View(getAllCategory);
        }

        public ActionResult getById(int id)
        {
            var getById = articleComponent.GetById(id);
            return View(getById);
        }


       public ActionResult Add()
        {
            var categoryMod = new ArticleBussinessModel()
            {
                Categories = categoryComponent.GetAll()
            };
            return View(categoryMod);
        } 

        [HttpPost]
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

        public ActionResult Edit(int id)
        {
           
            var toEdit = articleComponent.GetById(id);
            if(toEdit == null)
            {
                return RedirectToAction("GetAll");
            }
           
            var article = new ArticleBussinessModel()
            {
                ArticleId = toEdit.ArticleId,
                Title = toEdit.Title,
                Author = toEdit.Author,
                PublishedDate = toEdit.PublishedDate,
                Content = toEdit.Content,
                ImageURL = toEdit.ImageURL,
                Categories = categoryComponent.GetAll()
            };
            return View(article);
        }


        [HttpPost]
        public ActionResult EditNew(ArticleBussinessModel editedArticle)
        {
            var article = articleComponent.GetById(editedArticle.ArticleId);
            editedArticle.PublishedDate = DateTime.Now;
            
            if(editedArticle != null)
            {
                articleComponent.Update(editedArticle);
          
            }
            return RedirectToAction("GetAll");
        }

       
    }
}