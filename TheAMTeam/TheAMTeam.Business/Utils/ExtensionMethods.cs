using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.Business.Utils
{
    public static class ExtensionMethods
    {
        public static ArticleModel ToArticleModel(this Article article)
        {
            ArticleModel articleModel = new ArticleModel
            {
                ArticleId = article.ArticleId,
                Author = article.Author,
                Category = article.Category != null ? article.Category.ToCategoryModel() : null,
                Content = article.Content,
                ImageURL = article.ImageURL,
                PublishedDate = article.PublishedDate,
                Title = article.Title,
                CategoryId = article.CategoryId
            };

            return articleModel;
        }

        public static Article ToArticle(this ArticleModel articleModel)
        {
            Article article = new Article
            {
                ArticleId = articleModel.ArticleId,
                Author = articleModel.Author,
                Category  = articleModel.Category != null ? articleModel.Category.ToCategory() : null,                          
                CategoryId = articleModel.CategoryId,
                Content = articleModel.Content,
                ImageURL = articleModel.ImageURL,
                PublishedDate = articleModel.PublishedDate,
                Title = articleModel.Title
            };

            return article;
        }

        public static CategoryModel ToCategoryModel(this Category category)
        {
            CategoryModel categoryModel = new CategoryModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };

            return categoryModel;
        }

        public static Category ToCategory(this CategoryModel categoryModel)
        {
            Category category = new Category
            {
                CategoryId = categoryModel.CategoryId,
                Name = categoryModel.Name
            };

            return category;
        }


    }
}