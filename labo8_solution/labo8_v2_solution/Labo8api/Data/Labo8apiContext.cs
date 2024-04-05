using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labo8api.Models;

namespace Labo8api.Data
{
    public class Labo8apiContext : DbContext
    {
        public Labo8apiContext (DbContextOptions<Labo8apiContext> options)
            : base(options)
        {
        }

        public DbSet<Labo8api.Models.Animal> Animal { get; set; } = default!;
    }
}
