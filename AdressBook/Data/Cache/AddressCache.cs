using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Cache
{
    public class AddressCache : IAddressCache
    {
        List<Address> _cachedAddreses;

        public AddressCache()
        {
            InitializeCache();
        }

        public void InitializeCache()
        {
            _cachedAddreses = new List<Address>()
            {
                new Address { City = "bb", Number = "7A/5", PostalCode = "43-300", Street = "3 maja" },
                new Address { City = "katowice", Number = "144", PostalCode = "41-100", Street = "Chorzowska" }
            };
        }

        public List<Address> GetCache()
        {
            return _cachedAddreses;
        }
    }
}
