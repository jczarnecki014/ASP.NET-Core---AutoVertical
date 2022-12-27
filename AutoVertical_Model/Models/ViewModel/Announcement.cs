using AutoVertical_Utility.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class Announcement
    {
        public Vehicle vehicle{ get; set; }
        [ValidateNever]
        public List<ImgGallery>? images { get;set;}
    }
}
