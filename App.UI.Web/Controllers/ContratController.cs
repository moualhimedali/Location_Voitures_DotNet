using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace App.UI.Web.Controllers
{
    public class ContratController : Controller
    {
        IUnitOfWork unitOfWork;
        IServiceReservation reservationservice;
        IServiceContrat contratservice;
        IServiceVoiture voitureservice;

        public ContratController(IUnitOfWork unitOfWork, IServiceReservation reservationservice, IServiceContrat contratservice, IServiceVoiture voitureservice)
        {
            this.unitOfWork = unitOfWork;
            this.reservationservice = reservationservice;
            this.contratservice = contratservice;
            this.voitureservice = voitureservice;
        }
        private Context db = new Context();
        
        // GET: ContratController
        public ActionResult Index(int recherche)
        {
            float totalePrixLocation = db.Contrats.Select(x => x.NombreJoursLocation).Sum();
            ViewBag.TotalePrixLocation = totalePrixLocation * 150;


            float totalContrat = db.Contrats.Count();
            ViewBag.TotalContrat = totalContrat;
            return View(db.Contrats.Where(x => x.ReservationId.Equals(recherche) || recherche == 0).ToList());
            //return View(db.Reservations.Where(x => x.Trajet.StartsWith(recherche) || recherche == null).ToList());
            //return View(contratservice.GetAll());

        }


        // GET: ContratController/Details/5
        public ActionResult Details(int id)
        {
            return View(contratservice.GetById(id));
        }

        // GET: ContratController/Create
        public ActionResult Create()
        {
            ViewBag.ReservationId = new SelectList(reservationservice.GetAll(), "IdReservation", "IdReservation");
            ViewBag.VoitureId = new SelectList(voitureservice.GetAll(), "Matricule", "Matricule");
            return View();
        }

        // POST: ContratController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrat contrat)
        {
            if (!ModelState.IsValid)
                    return View();
            try
            {
                contratservice.Add(contrat);

                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContratController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ReservationId = new SelectList(reservationservice.GetAll(), "IdReservation", "IdReservation");
            ViewBag.VoitureId = new SelectList(voitureservice.GetAll(), "Matricule", "Matricule");
            return View(contratservice.GetById(id));
        }

        // POST: ContratController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrat contrat)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                contratservice.Update(contrat);

                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContratController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(contratservice.GetById(id));
        }

        // POST: ContratController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contrat contrat)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                contratservice.Delete(contrat);

                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
