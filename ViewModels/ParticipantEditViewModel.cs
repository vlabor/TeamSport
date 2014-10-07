using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamSport.Models;

namespace TeamSport.ViewModels
{
    public class ParticipantEditViewModel
    {
        public Participant CurrentParticipant { get; set; }

        public int SelectedGenderId { get; set; }
    }
}