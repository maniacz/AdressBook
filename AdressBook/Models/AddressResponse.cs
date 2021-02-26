using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBook.Models
{
    public class AddressResponse
    {
        //Tego propsa można wyciągnąć do osobnej klasy np. BaseResponse, po której klasy typu Response
        //mogłyby dziedziczyć, gdybyśmy mieli rozbudować aplikację o nowe Responsy
        public string ErrorMessage { get; set; }

        public Address LastSavedAddress { get; set; }

        public IEnumerable<Address> AddressesByCity { get; set; }
    }
}
