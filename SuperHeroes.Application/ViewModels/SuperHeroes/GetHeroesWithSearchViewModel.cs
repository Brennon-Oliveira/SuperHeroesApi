using SuperHeroes.Application.ViewModels.Commons;
using SuperHeroes.Domain.VOs.SuperHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperHeroes
{
    public class GetHeroesWithSearchViewModel: PaginationViewModel
    {
        public string? Search { get; set; }

        public GetSuperHeroesWithSearchVO ToGetHeroesWithSearchVO()
        {
            return new GetSuperHeroesWithSearchVO
            {
                Page = this.Page,
                PageSize = this.PageSize,
                Search = this.Search
            };
        }
    }
}
