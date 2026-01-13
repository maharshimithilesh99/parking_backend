
using ParkingApp.Data.Infrastructure;
namespace ParkingApp.Data.Repository
{
	public abstract class BaseRepository
	{
		protected readonly IConnectionFactory connectionFactory;
		public BaseRepository(IConnectionFactory connectionFactory)
		{
			this.connectionFactory = connectionFactory;
		}
	}
}

