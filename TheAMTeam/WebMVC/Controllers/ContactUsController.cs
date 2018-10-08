using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interface;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IUnitOfWorkComponent _unitOfWorkComponent;

        public ContactUsController(IUnitOfWorkComponent unitOfWorkComponent)
        {
            _unitOfWorkComponent = unitOfWorkComponent;
        }

        public ActionResult Index()
        {
            var result = _unitOfWorkComponent.Contacts.GetAllContacts();           

            return View(result);
        }

        //Search functionality
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var result = _unitOfWorkComponent.Contacts.GetAllContacts();

            var searchedList = result.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper()));
            
            if(searchedList.Count(x => x.Id > 0) == 0) ViewBag.NotFoundMessage = "There is no name in the database matching the search word";

            return View(searchedList);
        }

        //Add a new entry 
        public ActionResult Add()
        {
            var viewModel = new ContactModel();
            
            ViewBag.Departments = _unitOfWorkComponent.Departments.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewEntry(ContactModel myContact)
        {
            ViewBag.Departments = _unitOfWorkComponent.Departments.GetAll();

            if (ModelState.IsValid)
            {
                _unitOfWorkComponent.Contacts.Add(myContact);                
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
            var matchingUser = _unitOfWorkComponent.Contacts.GetById(myContact.Id);
            if(matchingUser == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unitOfWorkComponent.Departments.GetAll();

            return View(matchingUser);
        }

        [HttpPost]
        public ActionResult Update(ContactModel contactModelToUpdate)
        {
            ViewBag.Departments = _unitOfWorkComponent.Departments.GetAll();
     
            if (ModelState.IsValid)
            {
                _unitOfWorkComponent.Contacts.Update(contactModelToUpdate);
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
            var matchingUser = _unitOfWorkComponent.Contacts.GetById(contactToDelete.Id);
            if (matchingUser == null)
            {
                return RedirectToAction("Index");
            }
            return View(matchingUser);
        }
        [HttpPost]
        public ActionResult DeleteTheContact(int Id)
        {
            _unitOfWorkComponent.Contacts.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}