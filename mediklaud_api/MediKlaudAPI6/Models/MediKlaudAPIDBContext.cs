using Microsoft.EntityFrameworkCore;

namespace mediklaud_api.Models
{

  public class MediKlaudAPIDBContext : DbContext, IMediKlaudAPIDBContext
    {
        public MediKlaudAPIDBContext(DbContextOptions<MediKlaudAPIDBContext> options) : base(options)
        {

        }
        public DbSet<MemberMaster> MemberMasters { get; set; }
        public DbSet<UserAuthen> UserAuthens { get; set; }
    }
}
