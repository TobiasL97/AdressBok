using AdressBokWPF.MVVM.Models;
using AdressBokWPF.MVVM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TechTalk.SpecFlow.Analytics.UserId;
using FileService = AdressBokWPF.MVVM.Services.FileService;

namespace AdressBokWPF.MVVM.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private readonly FileService fileService;
        private string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ContactWPF.json";
        

        public ContactViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
        }

        [ObservableProperty]
        public bool isTextBoxVisible = false;

        [ObservableProperty]
        public bool isTextBlockVisible = true;

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [ObservableProperty]
        private string tb_FirstName = string.Empty;

        [ObservableProperty]
        private string tb_LastName = string.Empty;

        [ObservableProperty]
        private string tb_Email = string.Empty;

        [ObservableProperty]
        private string tb_PhoneNumber = string.Empty;

        [ObservableProperty]
        private string tb_Address = string.Empty;

        [ObservableProperty]
        private string tb_PostalCode = string.Empty;

        [ObservableProperty]
        private string tb_City = string.Empty;

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [RelayCommand]
        private void DeleteContact()
        {
            if(SelectedContact != null)
            {
                MessageBoxResult WarningBox = MessageBox.Show("Are you sure you want to remove this contact?", "Remove Contact", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == WarningBox)
                {
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].ContactId == SelectedContact.ContactId)
                        {
                            contacts.Remove(SelectedContact);
                            using var sw = new StreamWriter(filePath);
                            sw.WriteLine(JsonConvert.SerializeObject(contacts));

                            //Kunde inte använda fileService.Save() på denna som jag gjorde när jag uppdaterar en kontakt. Kontakten togs bort men när jag laddade om sidan så var den kvar.
                            //Gör jag på detta sättet så tas kontakten bort direkt och kontakten försvinner ur filen??
                        }
                    }
                }
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            
            IsTextBoxVisible = false;
            IsTextBlockVisible = true;
        }

        [RelayCommand]
        private void SaveContact()
        {
            SelectedContact.FirstName = Tb_FirstName;
            SelectedContact.LastName = Tb_LastName;
            SelectedContact.Email = Tb_Email;
            SelectedContact.PhoneNumber = Tb_PhoneNumber;
            SelectedContact.Address = Tb_Address;
            SelectedContact.PostalCode = Tb_PostalCode;
            SelectedContact.City = Tb_City;

            fileService.Save();

            SelectedContact = null!;

            IsTextBlockVisible = true;
            IsTextBoxVisible = false;

        }


        [RelayCommand]
        private void UpdateContact()
        {
            if (SelectedContact != null)
            {
                IsTextBlockVisible = false;
                IsTextBoxVisible = true;

                for (int i = 0; i < contacts.Count; i++)
                {
                    if (SelectedContact.ContactId == contacts[i].ContactId)
                    {
                        Tb_FirstName = Contacts[i].FirstName;
                        Tb_LastName = Contacts[i].LastName;
                        Tb_Email = Contacts[i].Email;
                        Tb_PhoneNumber = Contacts[i].PhoneNumber;
                        Tb_Address = Contacts[i].Address;
                        Tb_PostalCode = Contacts[i].PostalCode;
                        Tb_City = Contacts[i].City;
                    }
                }
            }
            
        }
    }
}
