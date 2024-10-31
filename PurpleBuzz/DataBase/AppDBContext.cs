using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Entities;

namespace PurpleBuzz.DataBase
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Aim> Aims { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
