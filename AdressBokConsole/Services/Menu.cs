using AdressBokConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdressBokConsole.Services
{
    internal class Menu
    {
        
        private FileService file = new();
        public string FilePath { get; set; } = null!;
        List<Contact> Contacts = new();
        
        public void StartMenu()
        {
            bool isActive = true;
            PopulateContactList();

            while(isActive)
            {
                Console.WriteLine(" Welcome to the contactbook, please choose an option\n 1. Add contact\n 2. Show all contacts\n 3. Show a specific contact\n 4. Remove contact\n 5. Exit the program");
                string Answer = Console.ReadLine() ?? "";
                switch(Answer)
                {
                    case "1":
                        OptionOne();
                        break;
                    
                    case "2":
                        OptionTwo();
                        break;

                    case "3":
                        OptionThree();
                        break;

                    case "4":
                        OptionFour();
                        break;

                    case "5":
                        isActive = false;
                        break;
                }
            }
        }

        private void PopulateContactList()
        {
            var List = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if(List != null)
            {
                Contacts = List;
            }
        }

        private void OptionOne()
        {
            Contact Contact = new();

            Console.Clear();
            Console.Write(" First name: ");
            Contact.FirstName = Console.ReadLine() ?? "";

            Console.Write(" Last name: ");
            Contact.LastName = Console.ReadLine() ?? "";

            Console.Write(" Email: ");
            Contact.Email = Console.ReadLine() ?? "";

            Console.Write(" Phonenumber: ");
            Contact.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write(" Address: ");
            Contact.Address = Console.ReadLine() ?? "";

            Console.Write(" Postalcode: ");
            Contact.PostalCode = Console.ReadLine() ?? "";

            Console.Write(" City: ");
            Contact.City = Console.ReadLine() ?? "";

            Contacts.Add(Contact);
            file.Save(FilePath, JsonConvert.SerializeObject(Contacts));
            Console.Clear();
        }

        private void OptionTwo()
        {
            Console.Clear();

            Console.WriteLine(" Your Contacts:\n");
            foreach (Contact Contact in Contacts)
            {
                Console.WriteLine($" {Contact.FirstName} {Contact.LastName}, {Contact.Email}\n");

            }
            Console.WriteLine("");
            Console.WriteLine(" Press any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
        }

        private void OptionThree()
        {
            Console.Clear();
        
            Console.WriteLine(" Type the first name of the contact\n");
            foreach (Contact Contact in Contacts)
            {
                Console.WriteLine($" {Contact.FirstName} {Contact.LastName}");
            }
            Console.WriteLine("");
            string Answer = Console.ReadLine() ?? "";
            for(int i = 0; i < Contacts.Count; i++)
            {
                
                if (Contacts[i].FirstName.ToLower().Equals(Answer))
                {
                    Console.Clear();
                    Console.WriteLine($" Details for {Contacts[i].FirstName} {Contacts[i].LastName}\n");
                    Console.WriteLine($" First name: {Contacts[i].FirstName}");
                    Console.WriteLine($" Last name: {Contacts[i].LastName}");
                    Console.WriteLine($" Email: {Contacts[i].Email}");
                    Console.WriteLine($" Phonenumber: {Contacts[i].PhoneNumber}");
                    Console.WriteLine($" Address: {Contacts[i].Address}, {Contacts[i].PostalCode}, {Contacts[i].City}");
                }
            }
            
            Console.ReadKey();
            Console.Clear();
        }

        private void OptionFour()
        {
            Console.Clear();
            Console.WriteLine(" Type the first name of the contact you want to remove\n");

            for (int i = 0; i < Contacts.Count; i++)
            {
                Console.WriteLine($" {Contacts[i].FirstName} {Contacts[i].LastName}");

            }
            Console.WriteLine();
            var RemoveContact = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" Are you sure you want to delete this contact? (Y or N)\n");
            string Answer = Console.ReadLine() ?? "";
            if(Answer.ToLower() == "y")
            {
                Contacts.RemoveAll(x => x.FirstName == RemoveContact);
                file.Save(FilePath, JsonConvert.SerializeObject(Contacts));
                Console.Clear();
            }
            else {
                Console.Clear();
            }
        }
    }
}
