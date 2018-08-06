using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.DataAccessLayer.Entities;


namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories
{
    public interface IArticlesRepository
    {
        
        Article Add(Article article);
        Article GetById(int id);
        Article Update(Article article);
        bool Delete(int id);
        List<Article> GetAll();
    }
}