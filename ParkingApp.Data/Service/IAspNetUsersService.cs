
using ParkingApp.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ParkingApp.Data.Service
{
	public partial interface IAspNetUsersService
	{
		Task<AspNetUsers> Get(string id);
		Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize);
		Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize,string sortBy, string orderBy);
		Task<int> Delete(string id);
		Task<int> Insert(AspNetUsers model);
		
		Task<int> Update(AspNetUsers model,string id);
		
	}
}

