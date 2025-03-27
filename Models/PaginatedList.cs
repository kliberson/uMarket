using System;
using System.Collections.Generic;

namespace uMarket.Models
{
    public class PaginatedList<T> where T : class
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages =>(int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
