using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class ImgGallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string imgOneUrl { get;set; }
        public string? imgTwoUrl { get;set; }
        public string? imgThreeUrl { get;set; }
        public string? imgFourUrl { get;set; }
        public string? imgFiveUrl { get;set;}
        public string? imgSixUrl { get;set;}
        public string? imgSevenUrl { get;set;}
        public string? imgEightUrl { get;set;}
    }
    
}
