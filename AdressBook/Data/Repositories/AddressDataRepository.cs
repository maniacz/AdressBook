using AdressBook.Cache;
using AdressBook.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Repositories
{
    public class AddressDataRepository : IAddressDataRepository
    {
        List<Address> _addresses;

        public AddressDataRepository()
        {
            _addresses = new List<Address>()
            {
                new Address { City = "bb", Number = "7A/5", PostalCode = "43-300", Street = "3 maja" },
                new Address { City = "katowice", Number = "144", PostalCode = "41-100", Street = "Chorzowska" }
            };
        }

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

            return _addresses.Where(a => a.City.Equals(city.ToLower()));
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
