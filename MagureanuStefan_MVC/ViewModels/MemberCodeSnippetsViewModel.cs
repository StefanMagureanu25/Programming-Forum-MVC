using MagureanuStefan_MVC.Models;

namespace MagureanuStefan_MVC.ViewModels
{
    public class MemberCodeSnippetsViewModel
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public List<CodeSnippetsModel> CodeSnippets = new List<CodeSnippetsModel>();
    }
}
