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
        public string SearchText { get; set; }

        public GetHeroesWithSearchVO ToGetHeroesWithSearchVO()
        {
            return new GetHeroesWithSearchVO
            {
                Page = this.Page,
                PageSize = this.PageSize,
                TotalPages = this.TotalPages,
                SearchText = this.SearchText
            };
        }
    }
}
