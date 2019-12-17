using CTrackAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI
{
    public class APIDataContext : DbContext
    {

        public APIDataContext(DbContextOptions<APIDataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Chitti> Chitti { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<People> People { get; set; }

        public DbSet<PaymentPaid> PaymentPaid { get; set; }

        public DbSet<Payments> Payments { get; set; }

        public DbSet<PaymentTaken> PaymentTaken { get; set; }
    }
}
