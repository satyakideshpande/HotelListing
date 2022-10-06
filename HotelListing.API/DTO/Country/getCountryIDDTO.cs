using System;
using HotelListing.API.DTO.Hotel;

namespace HotelListing.API.DTO.Country
{
    public class getCountryIDDTO : BaseCountryDTO// For individual get id
    {
        public int Id { get; set; }

        public List<GetHotelDTO> Hotels { get; set; }

    }
}

