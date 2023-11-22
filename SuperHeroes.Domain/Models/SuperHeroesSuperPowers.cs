using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Models
{
    public class SuperHeroesSuperPowers : BaseModel
    {
        public int SuperHeroesId { get; set; }
        public SuperHeroes SuperHeroe { get; set; }
        public int SuperPowersId { get; set; }
        public SuperPowers SuperPowers{ get; set; }
    }
}
