using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Models
{
    public class SuperHeroes : BaseModel
    {
        public required string Name { get; set; }
        public required string HeroName { get; set; }
        public DateTime? BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public ICollection<SuperHeroesSuperPowers> SuperPowers { get; set; }
    }
}
