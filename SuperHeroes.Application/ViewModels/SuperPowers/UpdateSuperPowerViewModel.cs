using SuperHeroes.Domain.VOs.SuperPowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.ViewModels.SuperPowers
{
    public class UpdateSuperPowerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public UpdateSuperPowerVO ToUpdateSuperPowerVO()
        {
            return new UpdateSuperPowerVO
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
