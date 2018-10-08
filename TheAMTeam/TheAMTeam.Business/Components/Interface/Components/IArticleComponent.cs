using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interface.Components
{
    public interface IArticleComponent
    {
        ArticleModel Add(ArticleModel articleModel);
        ArticleModel GetById(int id);
        List<ArticleModel> GetAll();
        ArticleModel Update(ArticleModel articleModelToUpdate);
        bool Delete(int id);

    }
}
