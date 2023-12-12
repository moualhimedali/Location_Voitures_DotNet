using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;

namespace App.UI.Web.Controllers
{
    public class ReservationController : Controller
    {

        IUnitOfWork unitOfWork;
        IServiceReservation reservationservice;
        IServiceClient clientservice;
        IServiceContrat contratservice;

        public ReservationController(IUnitOfWork unitOfWork, IServiceReservation reservationservice, IServiceClient clientservice, IServiceContrat contratservice)
        {
            this.unitOfWork = unitOfWork;
            this.reservationservice = reservationservice;
            this.clientservice = clientservice;
            this.contratservice = contratservice;
        }

        private Context db = new Context();
        // GET: ReservationController
        public ActionResult Index(int recherche)
        {
            int totalReservation = db.Reservations.Count();
            ViewBag.TotalReservation = totalReservation;
            return View(db.Reservations.Where(x => x.ClientId.Equals(recherche) || recherche == 0).ToList());
            //return View(reservationservice.GetAll());
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View(reservationservice.GetById(id));
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            ViewBag.MarqueVoiture = new SelectList(Enum.GetNames(typeof(MarqueVoiture)));
            ViewBag.EtatReservation = new SelectList(Enum.GetNames(typeof(EtatReservation)));
            ViewBag.ClientId = new SelectList(clientservice.GetAll(), "IdClient", "IdClient");
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                reservationservice.Add(reservation);

                unitOfWork.Commit();
                return RedirectToAction(nameof(MessagePage));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult MessagePage()
        {
            return View();
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MarqueVoiture = new SelectList(Enum.GetNames(typeof(MarqueVoiture)));
            ViewBag.Etat = new SelectList(Enum.GetNames(typeof(EtatReservation)));
            ViewBag.ClientId = new SelectList(clientservice.GetAll(), "IdClient", "IdClient");
            return View(reservationservice.GetById(id));
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reservation reservation)
        {
            try
            {
                reservationservice.Update(reservation);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(reservationservice.GetById(id));
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Reservation reservation)
        {
            try
            {
                reservationservice.Delete(reservation);
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
