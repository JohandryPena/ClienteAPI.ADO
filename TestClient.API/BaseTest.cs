using Client.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TestClient.API
{
	public class BaseTest
	{
		protected ClienteDbContext apllicationDbContext(string nombreBase) 
		{
			var options = new DbContextOptionsBuilder<ClienteDbContext>().UseInMemoryDatabase(nombreBase).Options;

			var dbContext = new ClienteDbContext(options);

			return dbContext;
		}


	}
}
