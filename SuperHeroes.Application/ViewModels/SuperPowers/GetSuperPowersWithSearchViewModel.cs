using SuperHeroes.Application.ViewModels.Commons;
using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperPowers
{
    public class GetSuperPowersWithSearchViewModel : PaginationViewModel
    {
        public string? Search { get; set; }

        public GetSuperPowersWithSearchVO ToGetSuperPowersWithSearchVO()
        {
            return new GetSuperPowersWithSearchVO
            {
                Search = Search,
                Page = Page,
                PageSize = PageSize
            };
        }
    }
}
