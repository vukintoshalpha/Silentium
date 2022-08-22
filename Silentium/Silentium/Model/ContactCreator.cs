using System;
using System.Collections.Generic;
using System.Text;

namespace Silentium.Model
{
    public class ContactCreator
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Number { get; set; }

        public ContactCreator(int id, string ime, string number)
        {
            Id = id;
            Ime = ime;
            Number = number;
        }

        public override string ToString()
        {
            return Ime + " " + Number;
        }
        public ContactCreator EditCopy()
        {
            return (ContactCreator)MemberwiseClone();
        }
        public Contact ToContact(ContactCreator contactCreator)
        {
            Contact contact = new Contact();
            contact.Id = contactCreator.Id;
            contact.Ime = contactCreator.Ime;
            contact.Number = contactCreator.Number;
            return contact;
        }
    }
}
