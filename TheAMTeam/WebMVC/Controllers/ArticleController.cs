using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interface;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IUnitOfWorkComponent _unitOfWorkComponent;

        public ArticleController(IUnitOfWorkComponent unitOfWorkComponent)
        {
            _unitOfWorkComponent = unitOfWorkComponent;
        }

        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

            [HttpGet]
        public ActionResult getAll()
        {
            var getAll = _unitOfWorkComponent.Articles.GetAll();
            
            return View(getAll);
        }

        public  ActionResult getAllCategoryId()
        {
            var getAllCategory = _unitOfWorkComponent.Categories.GetAll();
            return View(getAllCategory);
        }

        public ActionResult getById(int id)
        {
            var getById = _unitOfWorkComponent.Articles.GetById(id);
            return View(getById);
        }


       public ActionResult Add()
        {
            var categoryMod = new ArticleModel();
            ViewBag.Articles = _unitOfWorkComponent.Articles.GetAll();
            return View(categoryMod);
        } 

        [HttpPost]
       public ActionResult AddNew(ArticleModel fullArticle)
        {
            
            fullArticle.PublishedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var add = _unitOfWorkComponent.Articles.Add(fullArticle);
                return RedirectToAction("GetAll");
            }
            ViewBag.Articles = _unitOfWorkComponent.Categories.GetAll();
            return View("Add", fullArticle);

        }

        
        public ActionResult Delete(int id)
        {
            var toDelete = _unitOfWorkComponent.Articles.GetById(id);
            var deleted = toDelete != null ? _unitOfWorkComponent.Articles.Delete(toDelete.ArticleId) : false;

            return RedirectToAction("GetAll");
        }

        public ActionResult Edit(int id)
        {
           
            var toEdit = _unitOfWorkComponent.Articles.GetById(id);
            ViewBag.Categories = _unitOfWorkComponent.Categories.GetAll();
            if(toEdit == null)
            {
                return RedirectToAction("GetAll");
            }
           
            var article = new ArticleModel()
            {
                ArticleId = toEdit.ArticleId,
                Title = toEdit.Title,
                Author = toEdit.Author,
                PublishedDate = toEdit.PublishedDate,
                Content = toEdit.Content,
                ImageURL = toEdit.ImageURL,
                CategoryId = toEdit.CategoryId,
            };
            return View(article);
        }


        [HttpPost]
        public ActionResult EditNew(ArticleModel editedArticle)
        {
            var article = _unitOfWorkComponent.Articles.GetById(editedArticle.ArticleId);
            editedArticle.PublishedDate = DateTime.Now;
            ViewBag.Categories = _unitOfWorkComponent.Categories.GetAll();
            if (ModelState.IsValid)
            {
                _unitOfWorkComponent.Articles.Update(editedArticle);
                return RedirectToAction("Index");
            }
            return View("Edit", editedArticle);
        }

        [HttpPost]
        public ActionResult getAll(String search)
        {
            
                var getAll = _unitOfWorkComponent.Articles.GetAll();
                var searchResult = getAll.Where(x => x.Category.Name.Contains(search) || x.Title.Contains(search) || x.Author.Contains(search));
                if(searchResult.Count(x=>x.ArticleId > 0) == 0)
            {
                ViewBag.NotFound = "There is no Article with the specified keywords";
            }
            return View(searchResult);
            
        }

        [HttpGet]
        public ActionResult Blog()
        {
            var Blog = _unitOfWorkComponent.Articles.GetAll();

            return View(Blog);
        }
    }
}