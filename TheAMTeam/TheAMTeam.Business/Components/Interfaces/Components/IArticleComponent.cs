using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Business.Models;

namespace TheAMTeam.Business.Components.Interfaces
{
    public interface IArticleComponent
    {
        ArticleBussinessModel Add(ArticleBussinessModel articleModel);
        ArticleBussinessModel GetById(int id);
        List<ArticleBussinessModel> GetAll();
        ArticleBussinessModel Update(ArticleBussinessModel articleModelToUpdate);
        bool Delete(int id);
    }
}
