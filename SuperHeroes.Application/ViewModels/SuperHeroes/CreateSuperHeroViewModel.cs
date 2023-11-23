using SuperHeroes.Domain.VOs.SuperHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperHeroes
{
    public class CreateSuperHeroViewModel
    {
        public required string Name { get; set; }
        public required string HeroName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<int> SuperPowers { get; set; }

        public CreateSuperHeroVO ToCreateSuperHeroVO()
        {
            return new CreateSuperHeroVO
            {
                Name = this.Name,
                HeroName = this.HeroName,
                BirthDate = this.BirthDate,
                Height = this.Height,
                Weight = this.Weight,
                SuperPowers = this.SuperPowers
            };  
        }
    }
}
