using AdressBokWPF.MVVM.Models;
using AdressBokWPF.MVVM.Services;
using AdressBokWPF.MVVM.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAssertions;
using System.Collections.ObjectModel;
using System.Net;

namespace AdressBokWPF.Test
{
    public class ContactsViewModel_Test
    {
        private ContactViewModel contactViewModel;

        public ContactsViewModel_Test()
        {
            contactViewModel = new ContactViewModel();
        }

        [Fact]
        public void Should_Add_A_Contact_To_Contacts()
        {
            // Act
            ContactModel contact = new ContactModel { FirstName = "Tobias", LastName = "Larm", Email = "tobias@domain.com", Address = "Örebrovägen 1", PhoneNumber = "123456789", PostalCode = "12345", City = "Örebro" };
            contactViewModel.Contacts.Add(contact);

            // Assert
            contactViewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();
            contactViewModel.Contacts.Should().Contain(contact);
        }

        [Fact]
        public void Should_Remove_Contact_From_Contacts()
        {
            //Act

            ContactModel contact = new ContactModel { FirstName = "Tobias", LastName = "Larm", Email = "tobias@domain.com", Address = "Örebrovägen 1", PhoneNumber = "123456789", PostalCode = "12345", City = "Örebro" };
            contactViewModel.Contacts.Add(contact);
            contactViewModel.Contacts.Remove(contact);

            //Assert
            contactViewModel.Contacts.Should().NotContain(contact);
        }
    }
}