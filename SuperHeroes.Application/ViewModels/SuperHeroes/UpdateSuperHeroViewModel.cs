using SuperHeroes.Domain.VOs.SuperHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperHeroes
{
    public class UpdateSuperHeroViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HeroName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public List<int>? SuperPowers { get; set; }

        public UpdateSuperHeroVO ToUpdateSuperHeroVO()
        {
            return new UpdateSuperHeroVO
            {
                Id = Id,
                Name = Name,
                HeroName = HeroName,
                BirthDate = BirthDate,
                Height = Height,
                Weight = Weight,
                SuperPowers = SuperPowers
            };
        }
    }
}
