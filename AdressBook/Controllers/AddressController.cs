using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressBook.Repositories;
using AdressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressDataRepository _addressDataRepository;
        private readonly ILogger _logger;

        public AddressController(IAddressDataRepository addressDataRepository, ILogger<AddressController> logger)
        {
            _addressDataRepository = addressDataRepository;
            _logger = logger;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            AddressResponse response = new AddressResponse();

            try
            {
                response.LastSavedAddress = await Task.FromResult(_addressDataRepository.GetLastSavedAddress());
                _logger.LogInformation("Fetched last saved city.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                response.ErrorMessage = ex.Message;
            }

            return Ok(response.LastSavedAddress);
        }



        // GET api/<AddressController>/5
        [HttpGet("{city}")]
        public async Task<IActionResult> Get(string city)
        {
            AddressResponse response = new AddressResponse();

            try
            {
                response.AddressesByCity = await Task.FromResult(_addressDataRepository.GetAddressesByCity(city));
                _logger.LogInformation($"Fetched {city} by name.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                response.ErrorMessage = ex.Message;
                //todo: return Error
            }

            return Ok(response.AddressesByCity);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Address address)
        {
            var response = new AddressResponse();

            try
            {
                address.City.ToUpper();
                //todo: Kodowanie polskich znaków
                await Task.Run(() => _addressDataRepository.Add(address));
                _logger.LogInformation($"Added new addres {address.Street} {address.Number} {address.PostalCode} {address.City}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                response.ErrorMessage = ex.Message;
            }

            return Ok();
        }

        //todo: dorobić 
        //private void LogException(CityResponse out response, Exception ex)
        //{
        //    _logger.LogError(ex.Message, ex.StackTrace);
        //    response.ErrorMessage = ex.Message;
        //}
    }
}
