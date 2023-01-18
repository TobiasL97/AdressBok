using AdressBokWPF.MVVM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBokWPF.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();
        }

        private void Add()
        {

        }
    }
}
