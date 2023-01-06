using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public string UserOneId { get; set; }
        public string UserTwoId { get; set; }

        [NotMapped]
        public ApplicationUser? RecipientUser { get; set; }
        [NotMapped]
        public string? LoggedUserId { get; set; }
    }
}
