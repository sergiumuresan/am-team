using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Models
{
    public class ContactModelList
    {
        public ContactModel Contact { get; set; }

        public List<DepartmentModel> Departments = new List<DepartmentModel> {
            new DepartmentModel { Id = 1, Name = "Dep1" },
            new DepartmentModel { Id = 2, Name = "Dep2" },
            new DepartmentModel { Id = 3, Name = "Players" },
            new DepartmentModel { Id = 4, Name = "Press" }

        };
    }
}