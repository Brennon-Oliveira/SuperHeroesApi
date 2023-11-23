using SuperHeroes.Domain.VOs.SuperHeroesSuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.VOs.SuperHeroes
{
    public class GetFullSuperHeroVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeroName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<GetSuperHeroSuperPowerPowerVO> SuperPowers { get; set; }
    }
}
