using System;
using System.Collections.Generic;
using System.Text;

namespace Silentium.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return Ime + " " + Number;
        }
        public Contact EditCopy()
        {
            return (Contact)MemberwiseClone();
        }
    }
}
