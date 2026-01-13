
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingApp.Data.Infrastructure;
using ParkingApp.Data.UnitOfWork;
using ParkingApp.Data.Entities;

namespace ParkingApp.Data.Service
{
	public partial class AspNetUsersService : IAspNetUsersService
	{
		IUnitOfWork _unitOfWork;
		public AspNetUsersService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<AspNetUsers> Get(string id)
		{
			return await _unitOfWork.AspNetUsersRepository.Get(id);
		}
		public async Task<int> Delete(string id)
		{
			return await _unitOfWork.AspNetUsersRepository.Delete(id);
		}
		public async Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize)
		{
			return await _unitOfWork.AspNetUsersRepository.Search(pageIndex, pageSize);
		}
		public async Task<IEnumerable<AspNetUsers>> Search(int pageIndex, int pageSize,string sortBy, string orderBy)
		{
			return await _unitOfWork.AspNetUsersRepository.Search(pageIndex, pageSize,sortBy,orderBy);
		}
		public async Task<int> Insert(AspNetUsers usermodel)
		{
			return await _unitOfWork.AspNetUsersRepository.Insert(usermodel);
		}
		public async Task<int> Update(AspNetUsers usermodel,string id)
		{
			return await _unitOfWork.AspNetUsersRepository.Update(usermodel, id);
		}
	}
}

