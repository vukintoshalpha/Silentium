using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Silentium.Model;
using Silentium.Data;

namespace Silentium
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactEdit : ContentPage
    {
        int ident = 0;
        public ContactEdit()
        {
            InitializeComponent();
            Random random = new Random();
            random.Next(000000,999999);
            cId.Text = ident.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            Contact contactToSave = (Contact)this.BindingContext;
            contactToSave.Id = ident;
            await ContactsDatabase.GetDatabase().SaveContactAsync(contactToSave);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Contact contactToDelete = (Contact)this.BindingContext;
            await ContactsDatabase.GetDatabase().DeleteContactAsync(contactToDelete);
        }
    }
}