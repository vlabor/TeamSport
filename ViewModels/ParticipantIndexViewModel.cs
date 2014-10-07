using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamSport.Models;

namespace TeamSport.ViewModels
{
    public class ParticipantIndexViewItem
    {
        public int Id {get; set;}
        public string Name {get; set;}

        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate {get; set;}
        
        public string Gender {get; set;}
    }
    public class ParticipantIndexViewModel
    {
        private IEnumerable<Participant> _participants;

        public IEnumerable<Participant> Participants { 
            set 
            {
                _participants = value;
            } 
        }


        public IEnumerable<ParticipantIndexViewItem> ParticipantsList
        {
            get
            {
                if (_participants == null)
                    return null;

                return _participants.Select(n => new ParticipantIndexViewItem
                {
                    Id = n.Id,
                    Name = n.Name,
                    BirthDate = n.BirthDate,
                    Gender = n.Gender == null ? "" : n.Gender.GenderName
                }
                    );

            }
        }
    }
}