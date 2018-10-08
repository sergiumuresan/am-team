using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;
using TheAMTeam.Business.Utils;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.Business.Components.Interface.Components;


namespace TheAMTeam.Business.Components
{
    public class DepartmentComponent : IDepartmentComponent
    {
        readonly DepartmentRepository _departmentRepository;

        public DepartmentComponent()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public List<DepartmentModel> GetAll()
        {
            var result = _departmentRepository.GetAll();

            var returnList = new List<DepartmentModel>();

            foreach (var item in result)
            {
                returnList.Add(item.ToDepartmentModel());
            }

            return returnList;
        }
    }
}