using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class Advertisement
    {
        public int Id { get; set; }
        [ValidateNever]
        public string UserId { get;set;}   
        [Url]
        [Required]
        public string Url { get; set; }
        [ValidateNever]
        public string ImageSrc { get;set; }
        public string Size { get;set; }

        [Column(TypeName="date")]
        [Required]
        public DateTime ActiveFrom{ get;set;}
        [Column(TypeName="date")]
        [Required]
        public DateTime ActiveTo{ get;set;}
    }
}
