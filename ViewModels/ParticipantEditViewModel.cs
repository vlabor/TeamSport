using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamSport.Models;

namespace TeamSport.ViewModels
{
    public class ParticipantEditViewModel
    {
        public Participant CurrentParticipant { get; set; }

        public long SelectedGenderId { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }    
    }
}