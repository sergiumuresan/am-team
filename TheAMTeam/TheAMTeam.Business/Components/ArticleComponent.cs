using System.Collections.Generic;
using TheAMTeam.Business.Models;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Utils;
using TheAMTeam.Business.Components.Interfaces;

namespace TheAMTeam.Business.Components
{
    public class ArticleComponent : IArticleComponent
    {
        private readonly ArticlesRepository _articlesRepository;


        public ArticleComponent()
        {
            _articlesRepository = new ArticlesRepository();
        }

        public ArticleBussinessModel Add(ArticleBussinessModel articleModel)
        {
            var addedArticle = _articlesRepository.Add(articleModel.ToArticle());

            return addedArticle.ToArticleModel();
        }

        public ArticleBussinessModel GetById(int id)
        {
            ArticleBussinessModel result;
            result = _articlesRepository.GetById(id).ToArticleModel();
            return result;
        }

        public List<ArticleBussinessModel> GetAll()
        {
            var result = _articlesRepository.GetAll();

            var returnList = new List<ArticleBussinessModel>();

            foreach (var item in result)
            {
                returnList.Add(item.ToArticleModel());
            }

            return returnList;
        }

        public ArticleBussinessModel Update(ArticleBussinessModel articleModelToUpdate)
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