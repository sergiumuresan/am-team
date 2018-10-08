using System.Collections.Generic;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.DataAccessLayer.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Article Add(Article article);
        Article GetById(int id);
        Article Update(Article article);
        bool Delete(int id);
        List<Article> GetAll();

    }
}
