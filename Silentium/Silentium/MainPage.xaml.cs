using Silentium.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Silentium
{
    public partial class MainPage : ContentPage
    {
        ContactEdit contactEdit;
        public ObservableCollection<Contact> Data = App.Contacts;
        public MainPage()
        {
            InitializeComponent();
            ListView listView = new ListView();
            listView.ItemsSource = Data;
            listView.ItemTapped += ListView_ItemTapped;
            Main.Children.Add(listView);
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ContactEdit contactEdit = new ContactEdit();
            Contact contactToEdit = (Contact)(e.Item);
                    contactToEdit = contactToEdit.EditCopy();
            contactEdit.BindingContext = contactToEdit;
            await Navigation.PushAsync(contactEdit);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(contactEdit);
        }
    }
}
