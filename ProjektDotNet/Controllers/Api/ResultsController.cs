using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ProjektDotNet.Dtos;
using ProjektDotNet.Models;

namespace ProjektDotNet.Controllers.Api
{
    public class ResultsController : ApiController
    {
        private ApplicationDbContext _context;

        public ResultsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ResultDto> GetResult()
        {
           
            return _context.Results
                .Include(m => m.Competition)
                .Include(m => m.Player)
                .ToList()
                .Select(Mapper.Map<Result, ResultDto>);
        }

        public IHttpActionResult GetResult(int id)
        {
            var result = _context.Results.SingleOrDefault(c => c.Id == id);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<Result, ResultDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult CreateResult(ResultDto resultDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = Mapper.Map<ResultDto, Result>(resultDto);
            _context.Results.Add(result);
            _context.SaveChanges();

            resultDto.Id = result.Id;
            return Created(new Uri(Request.RequestUri + "/" + result.Id), resultDto);
        }

        [HttpPut]
       [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult UpdateResult(int id, ResultDto resultDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultInDb = _context.Results.SingleOrDefault(c => c.Id == id);

            if (resultInDb == null)
                return NotFound();

            Mapper.Map(resultDto, resultInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
       [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult DeleteResult(int id)
        {
            var resultInDb = _context.Results.SingleOrDefault(c => c.Id == id);

            if (resultInDb == null)
                return NotFound();

            _context.Results.Remove(resultInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
