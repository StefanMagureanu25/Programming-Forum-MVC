using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagureanuStefan_MVC.Models
{
    public class CodeSnippetsModel
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }

        [ForeignKey("IdMember")]
        public Guid IdMember { get; set; }

        [Range(1, 100, ErrorMessage = "Revision-ul poate fi intre 1 si 100!!!!")]
        public int Revision { get; set; }

        public DateTime DateTimeAdded { get; set; }

        //[Range(typeof(bool), "false", "true", ErrorMessage = "Trebuie sa selectati cel putin o optiune!!!")]
        public bool IsPublished { get; set; }
    }
}
