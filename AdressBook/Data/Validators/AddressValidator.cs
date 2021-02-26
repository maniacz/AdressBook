using AdressBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdressBook.Data.Validators
{
    public class AddressValidator : IAddressValidator
    {
        public void Validate(Address address)
        {
            Regex regex;

            string postalCodePattern = "^[0-9]{2}-[0-9]{3}$";
            regex = new Regex(postalCodePattern);
            if (!regex.IsMatch(address.PostalCode))
            {
                throw new Exception("Postal code is not valid.");
            }

            string addressNumberPattern = "^[0-9]";
            regex = new Regex(addressNumberPattern);
            if (!regex.IsMatch(address.Number))
            {
                throw new Exception("Number must start with a digit.");
            }

            string cityPattern = "^[a-zA-Z]";
            regex = new Regex(cityPattern);
            if (!regex.IsMatch(address.City))
            {
                throw new Exception("City must start with a letter.");
            }
        }
    }
}
