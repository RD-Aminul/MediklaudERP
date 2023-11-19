using Microsoft.EntityFrameworkCore;

namespace mediklaud_api.Models
{
    public interface IMediKlaudAPIDBContext
    {
        DbSet<MemberMaster> MemberMasters { get; set; }
        DbSet<UserAuthen> UserAuthens { get; set; }
    }
}
