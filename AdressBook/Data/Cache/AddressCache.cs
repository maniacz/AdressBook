using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Cache
{
    public class AddressCache : IAddressCache
    {
        IEnumerable<Address> _cachedAddreses;

        public void InitializeCache()
        {
            _cachedAddreses = new List<Address>();
        }
    }
}
