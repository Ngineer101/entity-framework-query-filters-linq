using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NWBlog.EntityFrameworkDemo.Api.Data
{
    public class DefaultContextFactory : IDefaultContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

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
    }
}
