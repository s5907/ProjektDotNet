using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjektDotNet.Models;
using ProjektDotNet.ViewModels;

namespace ProjektDotNet.Controllers
{
    public class ResultsController : Controller
    {
        private ApplicationDbContext _context;

        public ResultsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManage))
                return View("List");

            return View("ReadOnly");

      
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ViewResult New()
        {
            var competitions = _context.Competitions.ToList();
            var players = _context.Players.ToList();

            var viewModel = new ResultFormViewModel
            {
                Competitions = competitions,
                Players= players,
            };

            return View("ResultForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Edit(int id)
        {
            var result = _context.Results.SingleOrDefault(c => c.Id == id);

            if (result == null)
                return HttpNotFound();

            var viewModel = new ResultFormViewModel(result)
            {
                Competitions = _context.Competitions.ToList(),
                Players=_context.Players.ToList()
            };

            
            

            return View("ResultForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var result = _context.Results
                .Include(m => m.Competition).SingleOrDefault(m => m.Id == id);
             
                

            if (result == null)
                return HttpNotFound();

            return View(result);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Save(Result result)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ResultFormViewModel(result)
                {
                    Competitions = _context.Competitions.ToList(),
                    Players=_context.Players.ToList()
  
                };

                return View("ResultForm", viewModel);
            }

            if (result.Id == 0)
            {
                result.DateAdded = DateTime.Now;
                _context.Results.Add(result);
            }
            else
            {
                var resultInDb = _context.Results.Single(m => m.Id == result.Id);
                resultInDb.Name = result.Name;
                resultInDb.CompetitionId = result.CompetitionId;
                resultInDb.DateStart = result.DateStart;
                resultInDb.DateEnd = result.DateEnd;
                resultInDb.Place = result.Place;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Results");
        }
    }
}