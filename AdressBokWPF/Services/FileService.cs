
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AdressBokWPF.MVVM.Models;
using System.IO.Packaging;
using TechTalk.SpecFlow.Analytics.UserId;

namespace AdressBokWPF.MVVM.Services
{
    public class FileService
    {
        private readonly string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ContactWPF.json";
        private List<ContactModel> contacts;


        public FileService()
        {
            
            Read();
        }
        private void Read()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<ContactModel>(); }
        }

        public void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddContact(ContactModel Contact)
        {
            contacts.Add(Contact);
            Save();
        }

        public ObservableCollection<ContactModel> Contacts()
        {
            var items = new ObservableCollection<ContactModel>();
            foreach (var contact in contacts)
            {
                items.Add(contact);

            }
            
            return items;
        }
    }
}
