using System;
using System.Collections.Generic;

namespace uMarket.Models
{
    public class PaginatedList<T>(List<T> items, int totalCount, int pageNumber, int pageSize) where T : class
    {
        public List<T> Items { get; set; } = items;
        public int TotalCount { get; set; } = totalCount;
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public int TotalPages =>(int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
