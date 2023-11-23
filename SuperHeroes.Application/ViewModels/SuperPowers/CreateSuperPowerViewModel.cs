using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperPowers
{
    public class CreateSuperPowerViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public CreateSuperPowerVO ToCreateSuperPowerVO()
        {
            return new CreateSuperPowerVO
            {
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
