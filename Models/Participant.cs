using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;


namespace TeamSport.Models
{
    public class Participant
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }

    public class TeamSportDbContext :  DbContext 
    {
        public TeamSportDbContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public System.Data.Entity.DbSet<TeamSport.Models.Participant> Participants { get; set; }

        public System.Data.Entity.DbSet<TeamSport.Models.Gender> Gender { get; set; }


    }
}