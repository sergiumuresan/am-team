using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class ContactUsController : Controller
    {
        private ContactComponent contactComponent = new ContactComponent();

        private DepartmentComponent departmentComponent = new DepartmentComponent();


        //ContactUs/  -  show all the contact infos
        public ActionResult Index()
        {
            var result = contactComponent.GetAllContacts();           

            return View(result);
        }
             
        
        //Search functionality
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var result = contactComponent.GetAllContacts();

            var searchedList = result.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper()));
            
            if(searchedList.Count(x => x.Id > 0) == 0) ViewBag.NotFoundMessage = "There is no name in the database matching the search word";

            return View(searchedList);
        }


        //Add a new entry 
        public ActionResult Add()
        {
            var viewModel = new ContactModel();
            
            ViewBag.Departments = departmentComponent.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewEntry(ContactModel myContact)
        {
            ViewBag.Departments = departmentComponent.GetAll();

            if (ModelState.IsValid)
            {
                contactComponent.Add(myContact);                
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add", myContact);
            }
        }


        // Edit a contact
        public ActionResult Edit(ContactModel myContact)
        {
            var matchingUser = contactComponent.GetById(myContact.Id);
            if(matchingUser == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Departments = departmentComponent.GetAll();

            return View(matchingUser);
        }

        [HttpPost]
        public ActionResult Update(ContactModel contactModelToUpdate)
        {
            ViewBag.Departments = departmentComponent.GetAll();

            if (ModelState.IsValid)
            {
                contactComponent.Update(contactModelToUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", contactModelToUpdate);
            }
        }


        // Delete a contact
        public ActionResult Delete(ContactModel contactToDelete)
        {
            var matchingUser = contactComponent.GetById(contactToDelete.Id);
            if (matchingUser == null)
            {
                return RedirectToAction("Index");
            }
            return View(matchingUser);
        }
        [HttpPost]
        public ActionResult DeleteTheContact(int Id)
        {
            contactComponent.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}