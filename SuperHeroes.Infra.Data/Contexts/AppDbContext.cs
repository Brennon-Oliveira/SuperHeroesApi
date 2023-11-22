using Microsoft.EntityFrameworkCore;
using System;

namespace SuperHeroes.Infra.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}