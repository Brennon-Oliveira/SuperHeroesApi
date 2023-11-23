using SuperHeroes.Domain.VOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.VOs.SuperHeroes
{
    public class GetHeroesWithSearchVO : PaginationVO
    {
        public string SearchText { get; set; }
    }
}
