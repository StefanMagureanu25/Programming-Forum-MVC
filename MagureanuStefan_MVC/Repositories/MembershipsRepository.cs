using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Repositories
{
    public class MembershipsRepository
    {
        private readonly ClubLibraDbContext _context;
        public MembershipsRepository(ClubLibraDbContext context)
        {
            _context = context;
        }
        public DbSet<MembershipsModel> GetAllMemberships()
        {
            return _context.Memberships;
        }
        public void AddMembership(MembershipsModel membership)
        {
            membership.IdMembership = Guid.NewGuid();
            _context.Memberships.Add(membership);
            _context.SaveChanges();
        }
        public MembershipsModel GetMembershipById(Guid id)
        {
            var membership = _context.Memberships.FirstOrDefault(x => x.IdMembership == id);
            return membership;
        }
        public void UpdateMembership(MembershipsModel membership)
        {
            _context.Memberships.Update(membership);
            _context.SaveChanges();
        }
        public void DeleteMembership(Guid id)
        {
            var membership = _context.Memberships.FirstOrDefault(x => x.IdMembership == id);
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }
    }
}
