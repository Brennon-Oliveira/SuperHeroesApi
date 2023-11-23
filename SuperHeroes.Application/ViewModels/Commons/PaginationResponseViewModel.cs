using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.Commons
{
    public class PaginationResponseViewModel<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public List<T> Data { get; set; }
    }
}
