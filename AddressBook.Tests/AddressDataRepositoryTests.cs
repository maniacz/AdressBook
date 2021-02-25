using AdressBook.Cache;
using AdressBook.Repositories;
using Moq;
using System;
using Xunit;
using System.Collections.Generic;
using AdressBook.Entieties;
using System.Linq;

namespace AddressBook.Tests
{
    public class AddressDataRepositoryTests
    {
        private Mock<IAddressCache> _addressCache;

        public AddressDataRepositoryTests()
        {
            _addressCache = new Mock<IAddressCache>();
            _addressCache.Setup(c => c.GetCache()).Returns(
                new List<AdressBook.Entieties.Address>()
                {
                    new Address { City = "bb", Number = "7A/5", PostalCode = "43-300", Street = "3 maja" },
                    new Address { City = "katowice", Number = "144", PostalCode = "40-000", Street = "Chorzowska" },
                    new Address { City = "katowice", Number = "2", PostalCode = "40-000", Street = "Stawowa" }
                });
        }

        private AddressDataRepository Subject()
        {
            return new AddressDataRepository(_addressCache.Object);
        }

        [Fact]
        public void GetLastSavedAddress_ReturnsNotNull()
        {
            var repo = Subject();
            var lastSavedAddress = repo.GetLastSavedAddress();

            Assert.NotNull(lastSavedAddress);
        }

        [Fact]
        public void GetAll_ReturnsAllAddressesCount()
        {
            var repo = Subject();
            var addressCount = repo.GetAll().Count();

            Assert.Equal(3, addressCount);
        }

        [Fact]
        public void GetAddressesByCity_Katowice_Returns2Addreses()
        {
            var repo = Subject();
            var katowiceAddressCount = repo.GetAddressesByCity("katowice").Count();

            Assert.Equal(2, katowiceAddressCount);
        }
    }
}
