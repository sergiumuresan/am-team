using System.Collections.Generic;
using TheAMTeam.Business.Models;

using TheAMTeam.Business.Utils;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces;

namespace TheAMTeam.Business.Components
{
    public class ArticleComponent : IArticleComponent
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public ArticleComponent(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            
        }

        public ArticleModel Add(ArticleModel articleModel)
        {
            var addedArticle = _unitOfWorkRepository.Articles.Add(articleModel.ToArticle());

            return addedArticle.ToArticleModel();
        }

        public ArticleModel GetById(int id)
        {
            ArticleModel result;
            result = _unitOfWorkRepository.Articles.GetById(id).ToArticleModel();
            return result;
        }

        public List<ArticleModel> GetAll()
        {
            var result = _unitOfWorkRepository.Articles.GetAll();

            var returnList = new List<ArticleModel>();

            foreach (var item in result)
            {
                returnList.Add(item.ToArticleModel());
            }

            return returnList;
        }

        public ArticleModel Update(ArticleModel articleModelToUpdate)
        {
            var updated =_unitOfWorkRepository.Articles.Update(articleModelToUpdate.ToArticle());

            return updated.ToArticleModel();
        }

        public bool Delete(int id)
        {
            var deletedArticle = _unitOfWorkRepository.Articles.Delete(id);

            return deletedArticle;
        }
    }
}