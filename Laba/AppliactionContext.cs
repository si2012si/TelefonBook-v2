﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Laba
{
    class AppliactionContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public AppliactionContext() : base("DefaultConnection") { }

    }
}