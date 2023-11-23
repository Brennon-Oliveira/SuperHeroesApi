using SuperHeroes.Domain.VOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.VOs.SuperPowers
{
    public class GetSuperPowersWithSearchVO : PaginationVO
    {
        public string? Search { get; set; }
    }
}
