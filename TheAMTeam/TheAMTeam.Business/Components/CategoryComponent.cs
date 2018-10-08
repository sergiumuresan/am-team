using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Components.Interface.Components;


namespace TheAMTeam.Business.Components
{
    public class CategoryComponent : ICategoryComponent
    {
        private readonly CategoryRepository _categoryRepository;

        public List<CategoryModel> GetAll()
        {
            var result = _categoryRepository.GetAll();
            var returnList = new List<CategoryModel>();
            foreach(var item in result)
            {
                returnList.Add(item.ToCategoryModel());
            }
            return returnList;
        }
    }
}