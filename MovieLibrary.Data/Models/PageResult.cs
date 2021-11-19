using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Data.Models
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public PageResult(List<T> items, int totalCount, int pageSize, int pageNunmber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemFrom = pageSize * (pageNunmber - 1) + 1;
            ItemsTo = ItemFrom + pageSize - 1;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
