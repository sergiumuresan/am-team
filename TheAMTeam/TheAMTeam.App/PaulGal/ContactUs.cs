using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAMTeam.DataAccessLayer;
using TheAMTeam.DataAccessLayer.Entities;
using TheAMTeam.DataAccessLayer.Repositories;

namespace TheAMTeam.App.PaulGal
{
    public class ContactUs
    {
        private static readonly ContactRepository _contactUsRepository = new ContactRepository();

        public static void Execute()
        {
            //var contactU = CreateContactUs();
            //var savedContactU = SaveContactUs(contactU);
            
            int op = 0;
            do
            {
                Console.WriteLine(">>");
                op = System.Int32.Parse(System.Console.ReadLine());

                switch (op)
                {
                    case 1:
                        //1.Get all the values from the chosen table

                        foreach (Contact c in _contactUsRepository.GetAll()) 
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

                        Contact contact = _contactUsRepository.GetById(4);
                        contact.Name = "Dan";

                        _contactUsRepository.Update(contact);
                        break;
                    case 5:
                        //5.Delete the record with Id = 5

                        _contactUsRepository.Delete(5);
                        break;
                }
            } while (op != 0);

        }
        
        private static Contact CreateContactUs()
        {
            var contactUs = new Contact
            {
                Name = "John",
                Email = "John@yahoo.com",
                Phone = "0760601212",
                UserMessage="Mesaj",
                MessageDate=DateTime.Now
            };

            return contactUs;
        }
        
        private static Contact SaveContactUs(Contact contactUs)
        {
            var savedContactUs = _contactUsRepository.Add(contactUs);

            return savedContactUs;
        }

        private static void PrintContactUs(Contact contact)
        {
            Console.WriteLine(contact.Id + " " + contact.Name + " " + contact.Email);
        }
        
    }
}
