using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Cache.Repositories
{
    public interface IAddressDataRepository
    {
        void Add(Address address);

        IEnumerable<Address> GetAddressesByCity(string city);

        Address GetLastSavedAddress();
    }
}
