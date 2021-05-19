using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWBlog.EntityFrameworkDemo.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NWBlog.EntityFrameworkDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DefaultContext _context;

        public TestController(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all messages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Message>>> Get()
        {
            return await _context.Messages.ToListAsync();
        }
    }
}
