using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamSport.Models
{
    public class Gender
    {
        public long Id { get; set; }
        public string GenderName { get; set; }

        public static IEnumerable<Gender> GetItems()
        {
            return new List<Gender>
            {
                new Gender()
                {
                    Id = 1,
                    GenderName = "African American"
                },
                new Gender()
                {
                    Id = 2,
                    GenderName = "Caucasian"
                },
                new Gender()
                {
                    Id = 3,
                    GenderName = "Native American"
                }
            };
        }
    }
}
