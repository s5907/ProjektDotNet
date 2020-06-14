using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ProjektDotNet.Dtos;
using ProjektDotNet.Models;


namespace ProjektDotNet.Controllers.Api
{
    public class PlayersController : ApiController
    {
        private ApplicationDbContext _context;

        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }

       // GET /api/players
        public IHttpActionResult GetPlayers(string query = null)
        {

            ////var playerDtos = _context.Players
            ////    .Include(c => c.SportType)
            ////    .ToList()
            ////    .Select(Mapper.Map<Player, PlayerDto>);

            var playersQuery = _context.Players
               .Include(c => c.SportType);

            if (!String.IsNullOrWhiteSpace(query))
                playersQuery = playersQuery.Where(c => c.Name.Contains(query));
            var playerDtos = playersQuery
                .ToList()
                .Select(Mapper.Map<Player, PlayerDto>);


            return Ok(playerDtos);
        }

       // GET /api/players/1
        public IHttpActionResult GetPlayer(int id)
        {
            var player = _context.Players.SingleOrDefault(c => c.Id == id);

            if (player == null)
                return NotFound();

            return Ok(Mapper.Map<Player, PlayerDto>(player));
        }

      //  POST /api/players
       [HttpPost]
        public IHttpActionResult CreatePlayer(PlayerDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = Mapper.Map<PlayerDto, Player>(playerDto);
            _context.Players.Add(player);
            _context.SaveChanges();

            playerDto.Id = player.Id;
            return Created(new Uri(Request.RequestUri + "/" + player.Id), playerDto);
        }

      //  PUT /api/players/1
        [HttpPut]
        public IHttpActionResult UpdatePlayer(int id, PlayerDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var playerInDb = _context.Players.SingleOrDefault(c => c.Id == id);

            if (playerInDb == null)
                return NotFound();

            //////playerInDb.Name = playerDto.Name;
            //////playerInDb.Birthdate = playerDto.Birthdate;
            //////playerInDb.SportTypeId = playerDto.SportTypeId;
            //////playerInDb.HasLicense = playerDto.HasLicense;

            Mapper.Map(playerDto, playerInDb);

            _context.SaveChanges();

            return Ok();
        }

      //  DELETE /api/players/1
        [HttpDelete]
        public IHttpActionResult DeletePlayer(int id)
        {
            var playerInDb = _context.Players.SingleOrDefault(c => c.Id == id);

            if (playerInDb == null)
                return NotFound();

            _context.Players.Remove(playerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}