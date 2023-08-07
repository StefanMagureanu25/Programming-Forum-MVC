using System.ComponentModel.DataAnnotations;

namespace MagureanuStefan_MVC.Models
{
    public class MembershipTypesModel
    {
        [Key]
        public Guid IdMembershipType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubscriptionLengthInMonths { get; set; }
    }
}
