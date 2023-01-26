using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAdressBok.MVVM.Models;
using WPFAdressBok.Services;

namespace WPFAdressBok.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {

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
        private void AddContacts()
        {
            ContactService.AddContact(new ContactModel
            {
                FirstName = Tb_FirstName,
                LastName = Tb_LastName,
                Email = Tb_Email,
                PhoneNumber = Tb_PhoneNumber,
                Address = Tb_Address,
                PostalCode = Tb_PostalCode,
                City = Tb_City
            });

            Tb_FirstName = string.Empty;
            Tb_LastName = string.Empty;
            Tb_Email = string.Empty;
            Tb_PhoneNumber = string.Empty;
            Tb_Address = string.Empty;
            Tb_PostalCode = string.Empty;
            Tb_City = string.Empty;
        }
    }
}
