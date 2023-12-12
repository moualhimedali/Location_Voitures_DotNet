using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class VoitureController : Controller
    {
        IUnitOfWork unitOfWork;
        IServiceVoiture voitureservice;

        public VoitureController(IUnitOfWork unitOfWork, IServiceVoiture voitureservice)
        {
            this.unitOfWork = unitOfWork;
            this.voitureservice = voitureservice;
        }
        private Context db = new Context();
        // GET: VoitureController
        public ActionResult Index(int recherche)
        {
            int totalVoiture = db.Voitures.Count();
            ViewBag.TotalVoiture = totalVoiture;
            return View(db.Voitures.Where(x => x.NombrePlace.Equals(recherche) || recherche == 0).ToList());
            //return View(voitureservice.GetAll());
        }

        // GET: VoitureController/Details/5
        public ActionResult Details(string id)
        {
            return View(voitureservice.GetById(id));
        }

        // GET: VoitureController/Create
        public ActionResult Create()
        {
            ViewBag.CouleurVoiture = new SelectList(Enum.GetNames(typeof(CouleurVoiture)));
            return View();
        }

        // POST: VoitureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Voiture voiture)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                voitureservice.Add(voiture);

                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoitureController/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.CouleurVoiture = new SelectList(Enum.GetNames(typeof(CouleurVoiture)));
            return View(voitureservice.GetById(id));
        }

        // POST: VoitureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Voiture voiture)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                voitureservice.Update(voiture);

                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoitureController/Delete/5
        public ActionResult Delete(string id)
        {
            return View(voitureservice.GetById(id));
        }

        // POST: VoitureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Voiture voiture)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                voitureservice.Delete(voiture);

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
