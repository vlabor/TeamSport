using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TeamSport.Models
{
    public class Gender
    {
        [Required]
        public long Id { get; set; }
        
        [DisplayName("Gender")]
        public string GenderName { get; set; }
    }
}
