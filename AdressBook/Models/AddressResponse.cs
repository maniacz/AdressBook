using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Models
{
    public class AddressResponse
    {
        public string ErrorMessage { get; set; }

        public Address LastSavedAddress { get; set; }

        public IEnumerable<Address> AddressesByCity { get; set; }
    }
}
