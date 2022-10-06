using System;
using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTO.Country;
using HotelListing.API.DTO.Hotel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotelListing.API.AutoMapper
{
	public class MapperConfig :Profile
	{
		public MapperConfig() // helps maps between data type
		{
            CreateMap<Country, CountryDTO>().ReverseMap();
			CreateMap<Country, getCountryDTO>().ReverseMap();
            CreateMap<Country, getCountryIDDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<Hotel, GetHotelDTO>().ReverseMap();
            
        }
			
	}
}


