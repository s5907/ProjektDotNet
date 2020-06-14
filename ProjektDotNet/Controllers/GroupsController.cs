using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektDotNet.Models;
using ProjektDotNet.ViewModels;
using System.Data.Entity;

namespace ProjektDotNet.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext _context;

        public GroupsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Groups
        public ActionResult New()
        {
            return View();
        }


        public ViewResult Index()
        {

           // var group = new Group() { Id = 1 };
            var groups = _context.Groups
            .Include(m => m.Player)
            .Include(m => m.Trainer)
              .ToList();
           
            

            return View(groups);
           

        }

        public ViewResult Details(int? id)
        {
           
            var group = _context.Groups
                .Include(m => m.Player)
                .Include(m => m.Trainer)
                .SingleOrDefault(m => m.Id == id );
           


          
            return View(group);
        }
    }
}