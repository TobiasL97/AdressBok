using AdressBokWPF.MVVM.Models;
using AdressBokWPF.MVVM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdressBokWPF.MVVM.ViewModels
{
    public partial class UpdateContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public UpdateContactViewModel()
        {
            fileService = new();
            contacts = fileService.Contacts();
        }

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [ObservableProperty]
        private string comboText = "Select the contact you want to edit";

        [RelayCommand]
        private void UpdateContact()
        {
            if (SelectedContact != null)
            {
                MessageBoxResult WarningBox = MessageBox.Show("Are you sure you want update this contact?", "Update Contact", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == WarningBox)
                {
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].ContactId == SelectedContact.ContactId)
                        {
                            contacts[i].FirstName = SelectedContact.FirstName;
                            contacts[i].LastName = SelectedContact.LastName;
                            contacts[i].Email = SelectedContact.Email;
                            contacts[i].PhoneNumber = SelectedContact.PhoneNumber;
                            contacts[i].Address = SelectedContact.Address;
                            contacts[i].PostalCode = SelectedContact.PostalCode;
                            contacts[i].City = SelectedContact.City;

                            fileService.Save();
                            
                        }
                    }
                }
                else
                {
                    SelectedContact = null;
                    OnPropertyChanged();
                }
            }
        }
    }
}
