using Client.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;


namespace TestClient
{
    public class InMemoryDatabaseTest:IDisposable
    {
        public readonly DbContextOptions<ClienteDbContext> _options;
        public readonly ClienteDbContext _context;

        public InMemoryDatabaseTest()
        {
            _options = new DbContextOptionsBuilder<ClienteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ClienteDbContext(_options);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

