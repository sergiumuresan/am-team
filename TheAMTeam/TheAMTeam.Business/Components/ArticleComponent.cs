using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class ArticleComponent
    {
        private readonly ArticlesRepository _articlesRepository;

        public ArticleComponent()
        {
            _articlesRepository = new ArticlesRepository();
        }

    }
}