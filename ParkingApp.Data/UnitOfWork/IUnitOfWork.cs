
using System;

using ParkingApp.Data.Repository;
namespace ParkingApp.Data.UnitOfWork

{
	public interface IUnitOfWork : IDisposable
	{
		IAspNetUsersRepository AspNetUsersRepository  { get; }
        void Complete();
		
	}
}

