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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
