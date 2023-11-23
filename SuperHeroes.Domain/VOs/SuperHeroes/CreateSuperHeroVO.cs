using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.VOs.SuperHeroes
{
    public class CreateSuperHeroVO
    {
        public required string Name { get; set; }
        public required string HeroName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<int> SuperPowers { get; set; }
    }
}
