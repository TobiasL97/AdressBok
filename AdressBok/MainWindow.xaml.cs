using AdressBok.Models;
using AdressBok.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdressBok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> Contacts = new();
        private readonly FileService file = new();
        public MainWindow()
        {
            InitializeComponent();

           
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            PopulateContactsList();
        }

        private void PopulateContactsList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());
                if (items != null)
                {
                    Contacts = items;
                }
            }
            catch { };

            lv_ContactList.ItemsSource = Contacts;
        }

        private void ContactDetails()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());
                if (items != null)
                {
                    Contacts = items;
                }
            }
            catch { };

            lv_ContactDetail.ItemsSource = Contacts;
        }


        /// <summary>
        /// Visar formuläret för att lägga till en kontakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            lv_ContactDetail.Visibility= Visibility.Collapsed;
            g_Contacts.Visibility= Visibility.Collapsed;

            g_AddContact.Visibility= Visibility.Visible;
        }


        /// <summary>
        /// Lägger till en kontakt i Contacts-listan och döljer kontaktformuläret.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddContactForm_Click(object sender, RoutedEventArgs e)
        {
            Contacts.Add(new Contact
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                PhoneNumber = tb_Phonenumber.Text,
                Address = tb_address.Text,
                City = tb_city.Text
            });
            file.Save(JsonConvert.SerializeObject(Contacts));

            ClearForm();

            lv_ContactDetail.Visibility = Visibility.Visible;
            g_Contacts.Visibility = Visibility.Visible;

            g_AddContact.Visibility = Visibility.Collapsed;
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phonenumber.Text = "";
            tb_address.Text = "";
            tb_city.Text = "";

        }

        private void sp_Contacts_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ContactDetails();
        }
    }
}
