using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.DataAccessLayer.Repositories
{
    public class ArticlesRepository : IArticleRepository
    {
        private readonly IAppContext _context;

        public ArticlesRepository(IAppContext context)
        {
            _context = context;
        }

        public Article Add(Article article)
        {
            Article dbArticle;
            try
            {
                dbArticle = _context.Articles.Add(article);
                _context.SaveChanges();
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

                dbArticle = _context.Articles
                    .Include("Category")
                    .SingleOrDefault(c => c.ArticleId == id);

                _context.SaveChanges();

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
                //var unUpdate = context.Articles.FirstOrDefault(c => c.Author == upd.Author);
                _context.Articles.Attach(article);
                _context.Entry(article).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();                    
                
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
                dbArticle = _context.Articles.FirstOrDefault(c => c.ArticleId == id);
                _context.Articles.Remove(dbArticle);
                _context.SaveChanges();    
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
                return _context.Articles.Include("Category").ToList();   
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw(ex);
            }
        }
    }
}
