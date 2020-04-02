using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MagicRoyale_TeleportAndFire.App
{
    public class MagicRoyaleDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public MagicRoyaleDbContext(DbContextOptions<MagicRoyaleDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

    }
}
