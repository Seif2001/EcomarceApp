using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int maxPageSize = 50;

        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;

        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }
        private string _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}
