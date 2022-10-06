using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using AutoMapper;
using HotelListing.API.DTO.Country;
using HotelListing.API.IRepositoryContracts;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper,ICountriesRepository countriesRepository)
        {
           
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;

        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.Country.getCountryDTO>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<getCountryDTO>>(countries);
            return Ok(records);


          /*if (_context.Countries == null)
          {
              return NotFound();
          }
            return await _context.Countries.ToListAsync(); //as good as select * from countries*/
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<getCountryIDDTO>> GetCountry(int id)
        {

            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<getCountryIDDTO>(country);

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updatecountryDTO)
        {
            if (id != updatecountryDTO.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updatecountryDTO, country);


            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(DTO.Country.CountryDTO createCountry)
        {
            /*
            var country = new Country
            {
                Name = createCountry.Name,   //// We here are basically binding the data from Country.cs file to Country.DTO file
                ShortName = createCountry.ShortName
            };*/

            var country = _mapper.Map<Country>(createCountry); // This is a replacement of the above lines using Automapper. Injection was done in the above constructor class

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {

            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
