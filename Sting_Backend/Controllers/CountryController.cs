using Application.Interfaces;
using Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sting_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _countryService;

        public CountryController(ICountryServices countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(_countryService));
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<ActionResult<List<Countries>>> Get()
        {
            try
            {
                var result = await _countryService.Get();
                
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countries>> Get(int id)
        {
            try
            {
                var result = await _countryService.GetById(id);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] Countries countries)
        {
            try
            {
                var result = await _countryService.Create(countries);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<CountryController>/5
        [HttpPut()]
        public async Task<ActionResult<Countries>> Put([FromBody] Countries countries)
        {
            try
            {
                var result = await _countryService.Update(countries);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await _countryService.DeleteById(id);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
