using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTO.Country
{
	public class CountryDTO //DTO for POST
	{
		[Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

    }
}

