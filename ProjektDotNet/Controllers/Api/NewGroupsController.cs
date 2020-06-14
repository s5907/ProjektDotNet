using System;
using System.Linq;
using System.Web.Http;
using ProjektDotNet.Dtos;
using ProjektDotNet.Models;

namespace ProjektDotNet.Controllers.Api
{
    public class NewGroupsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewGroupsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewGroups(NewGroupDto newGroup)
        {
            var trainer = _context.Trainers.Single(
                c => c.Id == newGroup.TrainerId);

            var players = _context.Players.Where(
                m => newGroup.PlayerIds.Contains(m.Id)).ToList();

            foreach (var player in players)
            {
                var group = new Group
                {
                    Trainer = trainer,
                    Player = player,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now
                };

                _context.Groups.Add(group);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
