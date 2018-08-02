using System;
using System.Collections.Generic;
using System.Linq;
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

       
        //Add a new entry 
        public ActionResult Add()
        {          
            var viewModel = new ContactModel
            {
                Departments = departmentComponent.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewEntry(ContactModel myContact)
        {
            myContact.MessageDate = DateTime.Now;

            var newEntry = contactComponent.Add(myContact);

            return RedirectToAction("Index");
        }


        // Edit a contact
        public ActionResult Edit(ContactModel myContact)
        {
            var matchingUser = contactComponent.GetById(myContact.Id);
            if(matchingUser == null)
            {
                return RedirectToAction("Index");
            }

            matchingUser.Departments = departmentComponent.GetAll();

            return View(matchingUser);
        }

        [HttpPost]
        public ActionResult Update(ContactModel contactModelToUpdate)
        {
            contactModelToUpdate.MessageDate = DateTime.Now;

            contactComponent.Update(contactModelToUpdate);

            return RedirectToAction("Index");
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