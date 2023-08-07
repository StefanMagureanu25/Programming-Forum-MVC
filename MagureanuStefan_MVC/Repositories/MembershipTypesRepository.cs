using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ClubLibraDbContext _context;
        public MembershipTypesRepository(ClubLibraDbContext context)
        {
            _context = context;
        }
        public DbSet<MembershipTypesModel> GetAllMembershipTypes()
        {
            return _context.MembershipTypes;
        }
        public MembershipTypesModel GetMembershipTypeById(Guid id)
        {
            MembershipTypesModel model = _context.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id);
            return model;
        }
        public void AddMembershipType(MembershipTypesModel model)
        {
            model.IdMembershipType = Guid.NewGuid();
            _context.MembershipTypes.Add(model);
            _context.SaveChanges();
        }
        public void DeleteMembershipType(Guid id)
        {
            MembershipTypesModel model = _context.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id);
            _context.MembershipTypes.Remove(model);
            _context.SaveChanges();
        }
        public void UpdateMembershipType(MembershipTypesModel model)
        {
            _context.MembershipTypes.Update(model);
            _context.SaveChanges();
        }
        public bool HasMembership(Guid id)
        {
            return _context.Memberships.Any(x => x.IdMembership == id);
        }
    }
}
