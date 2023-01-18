using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBokWPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void AddContactView()
        {
            CurrentViewModel = new AddContactViewModel();
        }

        [RelayCommand]
        private void ContactView()
        {
            CurrentViewModel = new ContactViewModel();
        }

        public MainViewModel()
        {
            CurrentViewModel = new ContactViewModel();
        }
    }
}
