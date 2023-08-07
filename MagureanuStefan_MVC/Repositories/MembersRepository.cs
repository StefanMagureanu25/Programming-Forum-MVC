using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Repositories
{
    public class MembersRepository
    {
        public readonly ClubLibraDbContext _context;
        public MembersRepository(ClubLibraDbContext context)
        {
            _context = context;
        }
        public DbSet<MembersModel> GetAllMembers()
        {
            return _context.Members;
        }

        public MembersModel GetMemberById(Guid id)
        {
            MembersModel member = _context.Members.FirstOrDefault(x => x.IdMember == id);
            return member;
        }
        public void AddMember(MembersModel member)
        {
            member.IdMember = Guid.NewGuid();
            _context.Members.Add(member);
            _context.SaveChanges();
        }
        public void UpdateMember(MembersModel member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }
        public void DeleteMember(Guid id)
        {
            MembersModel member = GetMemberById(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid id)
        {
            MemberCodeSnippetsViewModel memberCodeSnippetsViewModel = new MemberCodeSnippetsViewModel();
            MembersModel member = GetMemberById(id);
            if (member != null)
            {
                memberCodeSnippetsViewModel.Name = member.Name;
                memberCodeSnippetsViewModel.Position = member.Position;
                memberCodeSnippetsViewModel.CodeSnippets = _context.CodeSnippets.Where(x => x.IdMember == id).ToList();
            }
            return memberCodeSnippetsViewModel;
        }
        public bool HasCodeSnippets(Guid id)
        {
            return _context.CodeSnippets.Any(x => x.IdMember == id);
        }
        public bool hasMemberships(Guid id)
        {
            return _context.Memberships.Any(x => x.IdMember == id);
        }
    }
}
