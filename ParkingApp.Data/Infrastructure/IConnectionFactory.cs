
using System;
using System.Data;

namespace ParkingApp.Data.Infrastructure
{
	public interface IConnectionFactory : IDisposable
	{
		IDbConnection GetConnection { get; }
	}
}

