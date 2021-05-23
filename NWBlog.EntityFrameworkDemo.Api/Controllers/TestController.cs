using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWBlog.EntityFrameworkDemo.Api.Data;
using NWBlog.EntityFrameworkDemo.Api.DTOs;
using NWBlog.EntityFrameworkDemo.Api.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Get messages paged
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        [HttpGet("paged")]
        public async Task<ActionResult<Page<Message>>> GetPaged(int skip, [Required]int take, string orderBy)
        {
            var page = await _context.Messages.ToPagedAsync(skip, take, orderBy);
            return Ok(page);
        }

        /// <summary>
        /// Get messages ordered by property name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        [HttpGet("ordered")]
        public async Task<ActionResult<List<Message>>> GetOrderBy(string propertyName)
        {
            var messages = await _context.Messages.OrderBy(propertyName).ToListAsync();
            return Ok(messages);
        }
    }
}
