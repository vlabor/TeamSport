using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace TeamSport.Models
{
    public class Participant
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }

    public class TeamSportDbContext :  DbContext 
    {

        public System.Data.Entity.DbSet<TeamSport.Models.Participant> Participants { get; set; }
    }
}