using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjektDotNet.Models;
using ProjektDotNet.ViewModels;
using System.Collections.Generic;


namespace ProjektDotNet.Controllers
{
   
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayersController()
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
            var viewModel = new PlayerFormViewModel
            {
                Player = new Player(),
                SportTypes = sportTypes
            };

            return View("PlayerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Player player)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PlayerFormViewModel
                {
                    Player = player,
                    SportTypes = _context.SportTypes.ToList()
                };

                return View("PlayerForm", viewModel);
            }

            if (player.Id == 0)
                _context.Players.Add(player);
            else
            {
                var playerInDb = _context.Players.Single(c => c.Id == player.Id);
                playerInDb.Name = player.Name;
                playerInDb.Birthdate = player.Birthdate;
                playerInDb.SportTypeId = player.SportTypeId;
                playerInDb.HasLicense = player.HasLicense;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Players");
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
           if (User.IsInRole(RoleName.CanManage))
                return View("List");
                return View("ReadOnly");

        }

        public ActionResult Details(int id)
        {
            var player = _context.Players.Include(c => c.SportType).SingleOrDefault(c => c.Id == id);


            if (player == null)
                return HttpNotFound();

            return View(player);
        }

        public ActionResult Edit(int id)
        {
            var player = _context.Players.SingleOrDefault(c => c.Id == id);

            if (player == null)
                return HttpNotFound();

            var viewModel = new PlayerFormViewModel
            {
                Player = player,
                SportTypes = _context.SportTypes.ToList(),
               
            };

            return View("PlayerForm", viewModel);
        }
    }
}