using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Notyfications
    {
        [Key]
        public int Id { get;set;}
        public string UserId { get;set;}
        public string Event { get;set;}
        public string UserOfEventId{ get;set;}
        [ForeignKey("UserOfEventId")]
        public ApplicationUser UserOfEvent { get;set;}
    }
}
