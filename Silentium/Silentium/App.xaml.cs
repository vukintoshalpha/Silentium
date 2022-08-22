using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Silentium.Model;
using Silentium.Data;

namespace Silentium
{
    public partial class App : Application
    {
        public static ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactEdit());
        }

        protected async override void OnStart()
        {
            List<Contact> Contacts = await ContactsDatabase.GetDatabase().GetContactsAsync();
            foreach (var item in Contacts)
            {
                Contacts.Add(item);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
