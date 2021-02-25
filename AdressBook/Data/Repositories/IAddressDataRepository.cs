using AdressBook.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Repositories
{
    public interface IAddressDataRepository
    {
        void Add(Address address);

        IEnumerable<Address> GetAddressesByCity(string city);

        Address GetLastSavedAddress();
    }
}
