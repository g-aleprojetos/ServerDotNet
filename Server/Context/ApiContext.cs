using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Context
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Logins { get; set; }



    }
}
