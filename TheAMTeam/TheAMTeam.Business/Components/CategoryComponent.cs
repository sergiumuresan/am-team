using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.Business.Components
{
    public class CategoryComponent
    {

        private readonly CategoryRepository _categoryRepository;


        public CategoryComponent()
        {
            _categoryRepository = new CategoryRepository();
        }
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