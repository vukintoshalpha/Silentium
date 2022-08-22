using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Silentium.Model;
using System.Threading.Tasks;
using System.IO;

namespace Silentium.Data
{
    internal class ContactsDatabase
    {
        private static ContactsDatabase instance;

        private static SQLiteAsyncConnection database;
        private static readonly string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.db3");

        private ContactsDatabase()
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Contact>().Wait();
        }

        public static ContactsDatabase GetDatabase()
        {
            if (instance == null)
            {
                instance = new ContactsDatabase();
            }

            return instance;
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return database.Table<Contact>().ToListAsync();
        }

        public Task<Contact> GetContactAsync(int Id)
        {
            return database.Table<Contact>()
                            .Where(i => i.Id == Id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveContactAsync(Contact contact)
        {
            if (contact.Id != -1)
            {
                return database.UpdateAsync(contact);
            }
            else
            {
                return database.InsertAsync(contact);
            }
        }

        public Task<int> DeleteContactAsync(Contact contact)
        {
            return database.DeleteAsync(contact);
        }

    }
}
