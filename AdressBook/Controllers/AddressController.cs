using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressBook.Cache.Repositories;
using AdressBook.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressDataRepository _addressDataRepository;

        public AddressController(IAddressDataRepository addressDataRepository)
        {
            _addressDataRepository = addressDataRepository;
        }



        //TODO: TRZEBA TO PRZEROBIĆ NA WIELOWĄTKOWE ASYNC AWAIT



        // GET: api/<AddressController>
        [HttpGet]
        public IActionResult Get()
        {
            CityResponse response = new CityResponse();

            try
            {
                response.LastSavedAddress = _addressDataRepository.GetLastSavedAddress();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return Ok(response.LastSavedAddress);
        }

        // GET api/<AddressController>/5
        [HttpGet("{city}")]
        public IActionResult Get(string city)
        {
            CityResponse response = new CityResponse();

            try
            {
                response.AddressesByCity = _addressDataRepository.GetAddressesByCity(city);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return Ok(response.AddressesByCity);
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] Address address)
        {
            //todo: dorobić klasę nadrzędną BaseResponse
            var response = new CityResponse();

            try
            {
                _addressDataRepository.Add(address);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
