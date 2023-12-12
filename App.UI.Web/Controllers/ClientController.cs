using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class ClientController : Controller
    {
        IUnitOfWork unitOfWork;
        IServiceReservation reservationservice;
        IServiceClient clientservice;
        IServiceContrat contratservice;

        public ClientController(IUnitOfWork unitOfWork, IServiceReservation reservationservice, IServiceClient clientservice, IServiceContrat contratservice)
        {
            this.unitOfWork = unitOfWork;
            this.reservationservice = reservationservice;
            this.clientservice = clientservice;
            this.contratservice = contratservice;
        }



        private Context db = new Context();
        
        
        // GET: ClientController
        public ActionResult Index(string recherche)
        {
            float totalClient = db.Clients.Count();
            ViewBag.TotalClient = totalClient;
            return View(db.Clients.Where(x => x.Nom.StartsWith(recherche) || recherche == null).ToList());

            //if (rechercheselon == "Nom" && rechercheselon == "Penom")
            //{
            //    return View(db.Clients.Where(x => x.Nom.StartsWith(recherche) || recherche == null).ToList());
            //}
            //else
            //{
            //    return View(db.Clients.Where(m => m.Prenom.StartsWith(recherche) || recherche == null).ToList());
            //}
            //return View(clientservice.GetAll());
        }


        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(clientservice.GetById(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client , IFormFile PhotoImage)
        {
            if (!ModelState.IsValid)


                return View();
            try
            {
                if (PhotoImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "images", PhotoImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PhotoImage.CopyTo(stream);
                    client.Photo = PhotoImage.FileName;
                }
                clientservice.Add(client);
                unitOfWork.Commit();
                return RedirectToAction(nameof(MessagePage));

            }
            catch
            {
                return View();
            }
        }
        //// GET: ClientController/LoginIn
        [HttpGet]
        public ActionResult LoginIn()
        {
            Client client = new Client();
            return View(client);
        }

        //// POST: ClientController/LoginIn
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginIn(Client client)
        {
            Context context = new Context();
            var status = context.Clients.Where(m=>m.Nom==client.Nom && m.MotDePasse==client.MotDePasse).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("SuccessPage", "Client");
            }
            return View(client);
        }
        public IActionResult SuccessPage()
        {
            return View();
        }
        public IActionResult MessagePage()
        {
            return View();
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(clientservice.GetById(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client, IFormFile PhotoImage)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                if (PhotoImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "images", PhotoImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PhotoImage.CopyTo(stream);
                    client.Photo = PhotoImage.FileName;
                }
                clientservice.Update(client);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(clientservice.GetById(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                clientservice.Delete(client);
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
