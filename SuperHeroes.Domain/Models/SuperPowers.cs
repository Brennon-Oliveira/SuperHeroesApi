using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Domain.Models
{
    public class SuperPowers : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<SuperHeroesSuperPowers> SuperHeroes { get; set; }
    }
}
