using System;
using HotelListing.API.Data;

namespace HotelListing.API.IRepositoryContracts
{
	public interface ICountriesRepository : IGenericRepository<Country>
	{
		Task<Country> GetDetails(int id);

	}
}

