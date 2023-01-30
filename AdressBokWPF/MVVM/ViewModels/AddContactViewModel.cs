using AdressBokWPF.MVVM.Models;
using AdressBokWPF.MVVM.Services;
using AdressBokWPF.MVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AdressBokWPF.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {

        private readonly FileService fileService;
        

        public AddContactViewModel()
        {
            fileService = new FileService();

        }

        

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
        public void Add(ContactModel contactModel)
        {
            fileService.AddContact(new ContactModel
            {
                FirstName = tb_FirstName,
                LastName = tb_LastName,
                Email = tb_Email,
                PhoneNumber = tb_PhoneNumber,
                Address = tb_Address,
                PostalCode = tb_PostalCode,
                City = tb_City
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
