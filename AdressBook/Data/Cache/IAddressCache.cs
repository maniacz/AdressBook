﻿using AdressBook.Entieties;
using System.Collections.Generic;

namespace AdressBook.Cache
{
    public interface IAddressCache
    {
        List<Address> GetCache();
    }
}