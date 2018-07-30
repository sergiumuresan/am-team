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

        //ContactUs/Update/id  -  updates a contact person by id
        public ActionResult Update(int id)
        {
            var playerToUpdate = contactComponent.GetById(id);

            return View(playerToUpdate);
        }


        



        public ActionResult Edit(ContactModel contactModel)
        {
            var matchinguser = contactComponent.GetById(contactModel.Id);
            if(matchinguser == null)
            {
                RedirectToAction("GetAll");
            }
            return View(matchinguser);
        }
    }
}