using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Data
{
    public class ClubLibraDbContext : DbContext
    {
        public DbSet<AnnouncementsModel> Announcements { get; set; }
        public DbSet<MembersModel> Members { get; set; }
        public DbSet<MembershipsModel> Memberships { get; set; }
        public DbSet<MembershipTypesModel> MembershipTypes { get; set; }
        public DbSet<CodeSnippetsModel> CodeSnippets { get; set; }
        public ClubLibraDbContext(DbContextOptions<ClubLibraDbContext> options) : base(options) { }
    }
}
