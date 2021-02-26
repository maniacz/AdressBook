using AdressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Data.Validators
{
    public interface IAddressValidator
    {
        void Validate(Address address);
    }
}
