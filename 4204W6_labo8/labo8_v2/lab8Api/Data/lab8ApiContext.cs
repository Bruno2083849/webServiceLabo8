using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab8Api.Model;

namespace lab8Api.Data
{
    public class lab8ApiContext : DbContext
    {
        public lab8ApiContext (DbContextOptions<lab8ApiContext> options)
            : base(options)
        {
        }

        public DbSet<lab8Api.Model.Animal> Animal { get; set; } = default!;
    }
}
