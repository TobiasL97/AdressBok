

using AdressBokConsole.Models;
using FluentAssertions;

namespace AdressBokConsole.Test
{
    public class ContactModel_Test
    {
        private Contact contact;
        private List<Contact> Contacts;
         
        public ContactModel_Test()
        {
            contact = new Contact();
            Contacts = new List<Contact>();
        }

        [Fact]
        public void Contact_Should_Contain_All_Properties_And_Should_Be_Added_To_Contacts()
        {
            //Act
            contact.FirstName = "Tobias";
            contact.LastName = "Larm";
            contact.Email = "tobias@domain.com";
            contact.Address = "Örebrovägen 1";
            contact.PhoneNumber = "123456789";
            contact.PostalCode= "12345";
            contact.City = "Örebro";

            Contacts.Add(contact);

            //assert
            contact.ContactId.Should().NotBeEmpty();
            contact.FirstName.Should().Be("Tobias");
            contact.LastName.Should().Be("Larm");
            contact.Email.Should().Be("tobias@domain.com");
            contact.Address.Should().Be("Örebrovägen 1");
            contact.PhoneNumber.Should().Be("123456789");
            contact.PostalCode.Should().Be("12345");
            contact.City.Should().Be("Örebro");
            Contacts.Should().Contain(contact);
            Contacts.Count().Should().Be(1);
            

        }
    }
}