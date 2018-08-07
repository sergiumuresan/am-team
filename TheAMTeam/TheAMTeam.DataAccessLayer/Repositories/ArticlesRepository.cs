using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly AppContext _context;
        public ArticlesRepository(AppContext context)
        {
            _context = context;
        }
        public ArticlesRepository()
        {
        }

        public Article Add(Article article)
        {
            Article dbArticle;
            try
            {
                using (var context = new AppContext())
                {
                    dbArticle = context.Articles.Add(article);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }

            return dbArticle;
        }

        public Article GetById(int id)
        {
            try
            {
                Article dbArticle;
                using (var context = new AppContext())
                {
                    dbArticle = context.Articles.Include("Category").SingleOrDefault(c => c.ArticleId == id);
                    context.SaveChanges();
                }
                return dbArticle;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }
        }

        public Article Update(Article article)
        {
            try
            {
                using (var context = new AppContext())
                {
                    //var unUpdate = context.Articles.FirstOrDefault(c => c.Author == upd.Author);
                    context.Articles.Attach(article);
                    context.Entry(article).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }
            return article;
        }

        public bool Delete(int id)
        {
            Article dbArticle;
            try
            {
                using (var context = new AppContext())
                {
                    dbArticle = context.Articles.FirstOrDefault(c => c.ArticleId == id);
                    context.Articles.Remove(dbArticle);
                    context.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }
            return dbArticle != null ? true : false;
        }

        public List<Article> GetAll()
        {
            try
            {
                using (var context = new AppContext())
                {
                    return context.Articles.Include("Category").ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }
        }
    }
}
