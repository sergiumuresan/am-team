using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.Data;
using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App.PaulGal
{
    public class Contact
    {
        private static readonly ContactUsRepository _contactUsRepository = new ContactUsRepository();

        public static void Execute()
        {
            //var contactU = CreateContactUs();
            //var savedContactU = SaveContactUs(contactU);
            
            int op = 0;
            do
            {
                op = System.Int32.Parse(System.Console.ReadLine());

                switch (op)
                {
                    case 1:
                        //1.Get all the values from the chosen table

                        foreach (ContactU c in _contactUsRepository.GetAll()) 
                        {
                            PrintContactUs(c);
                        }
                        break;
                    case 2:
                        //2.Get only the record with Id = 2
                        
                        PrintContactUs(_contactUsRepository.GetById(2));

                        break;
                    case 3:
                        //3.Add a new record in your table

                        SaveContactUs(CreateContactUs());
                        break;
                    case 4:
                        //4.Update the record with Id = 4

                        ContactU contact = _contactUsRepository.GetById(4);
                        contact.ContactName = "Dan";

                        _contactUsRepository.Update(contact);
                        break;
                    case 5:
                        //5.Delete the record with Id = 5

                        _contactUsRepository.Delete(5);
                        break;
                }
            } while (op != 0);

        }
        
        private static ContactU CreateContactUs()
        {
            var contactUs = new ContactU
            {
                ContactName = "John",
                Email = "John@yahoo.com",
                Phone = 725012542,
                UserMessage="Mesaj",
                MessageDate=DateTime.Now
            };

            return contactUs;
        }
        
        private static ContactU SaveContactUs(ContactU contactUs)
        {
            var savedContactUs = _contactUsRepository.Add(contactUs);

            return savedContactUs;
        }

        private static void PrintContactUs(ContactU contact)
        {
            Console.WriteLine(contact.FormId + " " + contact.ContactName + " " + contact.Email);
        }
        
    }
}
