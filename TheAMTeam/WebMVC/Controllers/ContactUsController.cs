using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Models;

namespace TheAMTeam.WebMVC.Controllers
{
    public class ContactUsController : Controller
    {
        private ContactComponent contactComponent = new ContactComponent();

        //ContactUs/GetAll  -  show all the contact infos
        public ActionResult GetAll()
        {
            var result = contactComponent.GetAllContacts();           

            return View(result);
        }

       
        //Add a new entry 
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewEntry(ContactModel myContact)
        {
            myContact.MessageDate = DateTime.Now;

            var newEntry = contactComponent.Add(myContact);

            return RedirectToAction("GetAll");
        }


        // Edit a contact
        public ActionResult Edit(ContactModel myContact)
        {
            var matchingUser = contactComponent.GetById(myContact.Id);
            if(matchingUser == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingUser);
        }

        [HttpPost]
        public ActionResult Update(ContactModel contactModelToUpdate)
        {
            contactModelToUpdate.MessageDate = DateTime.Now;

            contactComponent.Update(contactModelToUpdate);

            return RedirectToAction("GetAll");
        }


        // Delete a contact
        public ActionResult Delete(ContactModel contactToDelete)
        {
            var matchingUser = contactComponent.GetById(contactToDelete.Id);
            if (matchingUser == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(matchingUser);
        }
        [HttpPost]
        public ActionResult DeleteTheContact(int Id)
        {
            contactComponent.Delete(Id);

            return RedirectToAction("GetAll");
        }
    }
}