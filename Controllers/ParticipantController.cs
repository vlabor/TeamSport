using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamSport.Models;
using TeamSport.ViewModels;

namespace TeamSport.Controllers
{
    public class ParticipantController : Controller
    {
        private TeamSportDbContext db = new TeamSportDbContext();

        // GET: /Participant/
        public ActionResult Index()
        {
            ParticipantIndexViewModel pivmdl = new ParticipantIndexViewModel();
            pivmdl.Participants = db.Participants.Include(n => n.Gender).ToList();

            //return View(db.Participants.ToList());
            return View(pivmdl);
        }

        // GET: /Participant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Include(p => p.Gender).First(p => p.Id == id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: /Participant/Create
        public ActionResult Create()
        {
            var model = new ParticipantEditViewModel()
            {
                CurrentParticipant = null,
                SelectedGenderId = -1,
                Genders = new SelectList(db.Gender.AsEnumerable(), "ID", "GenderName")
            };
            
            return View("Create", model);

        }

        // POST: /Participant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParticipantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var participant = new Participant();
                participant.Gender = db.Gender.Find(model.SelectedGenderId);
                participant.Name = model.CurrentParticipant.Name;
                participant.BirthDate = model.CurrentParticipant.BirthDate;

                db.Participants.Add(participant);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Participant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var participant = db.Participants.FirstOrDefault(n => n.Id == id);
            if(participant == null)
                RedirectToAction("Index");

            var model = new ParticipantEditViewModel()
            {
                CurrentParticipant = participant,
                SelectedGenderId = participant.Gender == null ? (long?)null : participant.Gender.Id,
                Genders = new SelectList(db.Gender.AsEnumerable() , "ID", "GenderName")
            };

           
            return View("Edit", model);
        }

        // POST: /Participant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParticipantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var participant = db.Participants.Include(n => n.Gender).First(n => n.Id == model.CurrentParticipant.Id );
                participant.Name = model.CurrentParticipant.Name;
                participant.Gender = db.Gender.Find(model.SelectedGenderId);
                participant.BirthDate = model.CurrentParticipant.BirthDate;

                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        // GET: /Participant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: /Participant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
