using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WPFAdressBok.MVVM.Models;

namespace WPFAdressBok.Services
{
    public static class ContactService
    {
        private static ObservableCollection<ContactModel> contacts;
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\WPFContacts.Json");
        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.Read())!;
            }

            catch { new ObservableCollection<ContactModel>();  }
        }

        public static void AddContact(ContactModel model)
        {
            if(model != null)
            {
                contacts.Add(model);
                fileService.Save(JsonConvert.SerializeObject(contacts));
            }

        }

        public static void Remove(ContactModel model)
        {
            contacts.Remove(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }

        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
