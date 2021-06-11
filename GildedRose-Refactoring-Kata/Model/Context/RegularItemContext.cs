using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose_Refactoring_Kata.Model.Context
{
    public class RegularItemContext : DbContext
    {
        public RegularItemContext(DbContextOptions<RegularItemContext> options)
            : base(options)
        {
        }

        public DbSet<RegularItem> RegularItems { get; set; }
        public DbSet<ConjuredItem> ConjuredItems { get; set; }
        public DbSet<LegendaryItem> LegendaryItems { get; set; }
        public DbSet<AgedItem> AgedItems { get; set; }
        public DbSet<BackstagePassItem> BackstagePassItems { get; set; }

    }
}
