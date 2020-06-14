using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ProjektDotNet.Dtos;
using ProjektDotNet.Models;


namespace ProjektDotNet.Controllers.Api
{
  
    public class TrainersController : ApiController
    {
        private ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/trainers
        public IHttpActionResult GetTrainers(string query = null)
        {

            var trainersQuery = _context.Trainers
              .Include(c => c.SportType)
              .Include(c => c.Player);

            if (!String.IsNullOrWhiteSpace(query))
                trainersQuery = trainersQuery.Where(c => c.Name.Contains(query));
            var trainerDtos = trainersQuery
                .ToList()
                .Select(Mapper.Map<Trainer, TrainerDto>);

            //////var trainerDtos = _context.Trainers
            //////    .Include(c => c.SportType)
            //////    .Include(c => c.Player)
            //////    .ToList()
            //////    .Select(Mapper.Map<Trainer, TrainerDto>);


            return Ok(trainerDtos);

        }

        // GET /api/trainer/1
        public IHttpActionResult GetTrainer(int id)
        {
            var trainer = _context.Trainers.SingleOrDefault(c => c.Id == id);

            if (trainer == null)
                return NotFound();

            return Ok(Mapper.Map<Trainer, TrainerDto>(trainer));
        }

        //  POST /api/trainers
        [HttpPost]
        public IHttpActionResult CreateTrainer(TrainerDto trainerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trainer = Mapper.Map<TrainerDto, Trainer>(trainerDto);
            _context.Trainers.Add(trainer);
            _context.SaveChanges();

            trainerDto.Id = trainer.Id;
            return Created(new Uri(Request.RequestUri + "/" + trainer.Id), trainerDto);
        }

        //  PUT /api/trainer/1
        [HttpPut]
        public IHttpActionResult UpdateTrainer(int id, TrainerDto trainerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trainerInDb = _context.Trainers.SingleOrDefault(c => c.Id == id);

            if (trainerInDb == null)
                return NotFound();

            Mapper.Map(trainerDto, trainerInDb);

            _context.SaveChanges();

            return Ok();
        }

        //  DELETE /api/trainers/1
        [HttpDelete]
        public IHttpActionResult DeleteTrainer(int id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(c => c.Id == id);

            if (trainerInDb == null)
                return NotFound();

            _context.Trainers.Remove(trainerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}