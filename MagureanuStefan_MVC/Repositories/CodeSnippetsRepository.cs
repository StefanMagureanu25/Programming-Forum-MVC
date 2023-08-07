using MagureanuStefan_MVC.Data;
using MagureanuStefan_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MagureanuStefan_MVC.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ClubLibraDbContext _context;
        public CodeSnippetsRepository(ClubLibraDbContext context)
        {
            _context = context;
        }
        public DbSet<CodeSnippetsModel> GetAllCodeSnippets()
        {
            return _context.CodeSnippets;
        }
        public void Delete(Guid idCodeSnippet)
        {
            var codeSnippet = _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == idCodeSnippet);
            _context.CodeSnippets.Remove(codeSnippet);
            _context.SaveChanges();
        }
        public CodeSnippetsModel? GetCodeSnippetById(Guid idCodeSnippet)
        {
            return _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == idCodeSnippet);
        }
        public void AddCodeSnippet(CodeSnippetsModel codeSnippet)
        {
            codeSnippet.IdCodeSnippet = Guid.NewGuid();
            _context.CodeSnippets.Add(codeSnippet);
            _context.SaveChanges();
        }
        public void UpdateCodeSnippet(CodeSnippetsModel codeSnippet)
        {
            _context.CodeSnippets.Update(codeSnippet);
            _context.SaveChanges();
        }
    }
}
