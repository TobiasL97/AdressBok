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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public ContactModel selectedContact = null!;

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

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
        private void UpdateContact()
        {
            if (SelectedContact != null)
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
        }
    }
}
