using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAdressBok.MVVM.Models;
using WPFAdressBok.Services;

namespace WPFAdressBok.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();
    };
}
