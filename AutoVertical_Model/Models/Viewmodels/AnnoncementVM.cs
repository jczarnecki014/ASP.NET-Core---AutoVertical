using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.Viewmodels
{
    public class AnnoncementVM
    {
        public Vehicle vehicle { get; set; }

        [ValidateNever]
        public Car car { get;set; }

        [ValidateNever]
        public Truck truck { get; set; }

        [ValidateNever]
        public Motorcycle motorcycle{ get; set; }
    }
}
