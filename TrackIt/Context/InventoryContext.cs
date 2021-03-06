﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackIt.Entities;
using TrackIt.Models;

namespace TrackIt.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
