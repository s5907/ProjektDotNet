using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjektDotNet.Models;
using ProjektDotNet.ViewModels;
using System.Collections.Generic;


namespace ProjektDotNet.Controllers
{
    [AllowAnonymous]
    public class TrainersController : Controller
    {
        private ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult New()
        {
            var sportTypes = _context.SportTypes.ToList();
            var players = _context.Players.ToList();

            var viewModel = new TrainerFormViewModel
            {
                Trainer = new Trainer(),
                SportTypes = sportTypes,
                Players = players,
            };

            return View("TrainerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TrainerFormViewModel
                {
                    Trainer = trainer,
                    SportTypes = _context.SportTypes.ToList(),
                    Players = _context.Players.ToList()
                };

                return View("TrainerForm", viewModel);
            }

            if (trainer.Id == 0)
                _context.Trainers.Add(trainer);
            else
            {
                var trainerInDb = _context.Trainers.Single(c => c.Id == trainer.Id);
                trainerInDb.Name = trainer.Name;
                trainerInDb.Birthdate = trainer.Birthdate;
                trainerInDb.SportTypeId = trainer.SportTypeId;
                trainerInDb.PlayerId = trainer.PlayerId;
                trainerInDb.HasLicense = trainer.HasLicense;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Trainers");
        }

        public ViewResult Index()
        {
             if (User.IsInRole(RoleName.CanManage))
            return View();
                return View("ReadOnly");

        }

        public ActionResult Details(int id)
        {
            var trainer = _context.Trainers
                .Include(c => c.SportType)
                .Include(c => c.Player)
                .SingleOrDefault(c => c.Id == id);


            if (trainer == null)
                return HttpNotFound();

            return View(trainer);
        }

        public ActionResult Edit(int id)
        {
            var trainer = _context.Trainers.SingleOrDefault(c => c.Id == id);

            if (trainer == null)
                return HttpNotFound();

            var viewModel = new TrainerFormViewModel
            {
                Trainer = trainer,
                SportTypes = _context.SportTypes.ToList(),
                Players = _context.Players.ToList(),
            };

            return View("TrainerForm", viewModel);
        }
    }
}