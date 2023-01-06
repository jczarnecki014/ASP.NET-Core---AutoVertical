using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ConversationId { get;set; }

        [NotMapped]
        public Conversation Conversation{ get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser MessageSenderUser { get;set; }
        [Required]
        public DateTime Date{get;set;}
        [Required]
        public string Contents { get; set; }
    }
}
