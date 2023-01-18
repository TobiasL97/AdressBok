
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

namespace AdressBokWPF.MVVM.Services
{
    class FileService
    {
        private string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ContactWPF.json";
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

        private void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddContact(ContactModel Contact)
        {
            contacts.Add(Contact);
            Save();
        }
    }
}
