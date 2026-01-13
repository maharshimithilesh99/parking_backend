
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingApp.Data.Entities;


namespace ParkingApp.Data.Repository
{
	public partial interface IAspNetUsersRepository
	{
		Task<AspNetUsers> Get(string id);
		Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize);
		Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize,string sortBy, string orderBy);
		Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize,string sortBy, string orderBy,string searchstring);
		Task<int> Insert(AspNetUsers model);
		Task<int> Update(AspNetUsers model,string id);
		Task<int> Delete(string id);
	}
}

