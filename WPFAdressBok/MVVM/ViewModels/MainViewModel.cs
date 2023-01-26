using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAdressBok.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void AddContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void Home() => CurrentViewModel = new ContactsViewModel();
    }
}
