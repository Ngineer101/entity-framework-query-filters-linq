using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NWBlog.EntityFrameworkDemo.Api.Data
{
    public class DefaultContextFactory : IDefaultContextFactory, IDesignTimeDbContextFactory<DefaultContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public DefaultContextFactory() { }

        public DefaultContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public DefaultContext CreateContext()
        {
            var signedInUser = _httpContextAccessor.HttpContext.User ?? null;
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseSqlite(_configuration.GetConnectionString("DefaultConnectionString"))
                .Options;

            return new DefaultContext(options, signedInUser?.Identity?.Name, signedInUser?.IsInRole("admin") ?? false);
        }

        public DefaultContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseSqlite("Data Source=demoDb.db")
                .Options;

            return new DefaultContext(options);
        }
    }
}
