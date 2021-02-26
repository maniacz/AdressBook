using AdressBook.Cache;
using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Repositories
{
    public class AddressDataRepository : IAddressDataRepository
    {
        List<Address> _addresses;


        public AddressDataRepository(IAddressCache addressCache)
        {
            _addresses = addressCache.GetCache();
        }

        public IEnumerable<Address> GetAddressesByCity(string city = null)
        {
            if (city is null)
            {
                return GetAll();
            }

            return _addresses.Where(a => a.City.Equals(city.ToUpper()));
        }

        public Address GetLastSavedAddress()
        {
            return _addresses.LastOrDefault();
        }

        public IEnumerable<Address> GetAll()
        {
            return _addresses;
        }

        public void Add(Address address)
        {
            _addresses.Add(address);
        }
    }
}
