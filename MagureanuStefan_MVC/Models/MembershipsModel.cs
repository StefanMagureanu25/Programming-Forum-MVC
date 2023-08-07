using System.ComponentModel.DataAnnotations;

namespace MagureanuStefan_MVC.Models
{
    public class MembershipsModel
    {
        [Key]
        public Guid IdMembership { get; set; }

        public Guid IdMember { get; set; }

        public Guid IdMembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Level;
    }
}
