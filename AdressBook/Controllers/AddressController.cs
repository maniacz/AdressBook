using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressBook.Repositories;
using AdressBook.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdressBook.Data.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressDataRepository _addressDataRepository;
        private readonly ILogger _logger;
        private readonly IAddressValidator _addressValidator;

        public AddressController(IAddressDataRepository addressDataRepository, ILogger<AddressController> logger, IAddressValidator addressValidator)
        {
            _addressDataRepository = addressDataRepository;
            _logger = logger;
            _addressValidator = addressValidator;
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
                return BadRequest(response.ErrorMessage);
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
                return BadRequest(response.ErrorMessage);
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
                _addressValidator.Validate(address);
                address.City = address.City.ToUpper();

                await Task.Run(() => _addressDataRepository.Add(address));
                _logger.LogInformation($"Added new addres {address.Street} {address.Number} {address.PostalCode} {address.City}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                response.ErrorMessage = ex.Message;
                return BadRequest(response.ErrorMessage);
            }

            return Ok();
        }
    }
}
