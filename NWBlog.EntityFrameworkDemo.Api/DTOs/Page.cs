using System.Collections.Generic;

namespace NWBlog.EntityFrameworkDemo.Api.DTOs
{
    public class Page<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalItemCount { get; set; }

        public Page() { }

        public Page(IEnumerable<T> items, int totalItemCount)
        {
            Items = items;
            TotalItemCount = totalItemCount;
        }
    }
}
