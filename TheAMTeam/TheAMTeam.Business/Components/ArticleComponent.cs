using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.Business.Utils;

namespace TheAMTeam.Business.Components
{
    public class ArticleComponent
    {
        private readonly ArticlesRepository _articlesRepository;

        public ArticleComponent()
        {
            _articlesRepository = new ArticlesRepository();
        }

        public ArticleModel Add(ArticleModel articleModel)
        {
            var addedArticle = _articlesRepository.Add(articleModel.ToArticle());

            return addedArticle.ToArticleModel();
        }

        public ArticleModel GetById(int id)
        {
            ArticleModel result;
            result = _articlesRepository.GetById(id).ToArticleModel();
            return result;
        }

        public List<ArticleModel> GetAll()
        {
            var result = _articlesRepository.GetAll();

            var returnList = new List<ArticleModel>();

            foreach (var item in result)
            {
                returnList.Add(item.ToArticleModel());
            }

            return returnList;
        }

        public ArticleModel Update(ArticleModel articleModelToUpdate)
        {
            var updated =_articlesRepository.Update(articleModelToUpdate.ToArticle());

            return updated.ToArticleModel();
        }

        public bool Delete(int id)
        {
            var deletedArticle = _articlesRepository.Delete(id);

            return deletedArticle;
        }
    }
}