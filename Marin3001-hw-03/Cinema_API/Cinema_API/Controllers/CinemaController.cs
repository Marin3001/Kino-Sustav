using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cinema_API.Models;
using Cinema_API.Controllers.DTO;
using Cinema_API.Filters;
using Cinema_API.Controllers;
using Cinema_API.Logic;
using static Cinema_API.Filters.FilterLog;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema_API.Repositories;

namespace Cinema_API.Controllers
{
    [LogFilter]
    [ApiController]
    [Route("api/[controller]")]
    
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaLogic cinemaLogic;

        public CinemaController(ICinemaLogic cinemaLogic)
        {
            this.cinemaLogic = cinemaLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cinema>> Get()
        {
            var allCinemas = cinemaLogic.GetAllCinemas();
            return Ok(allCinemas);
        }

        [HttpGet("{id}")]
        public ActionResult<Cinema> Get(int id)
        {
            var cinema = cinemaLogic.GetCinemaById(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cinema cinema)
        {
            if (cinema == null)
            {
                return BadRequest();
            }

            cinemaLogic.AddCinema(cinema);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cinema = cinemaLogic.GetCinemaById(id);
            if (cinema == null)
            {
                return NotFound();
            }

            cinemaLogic.DeleteCinema(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cinema updatedCinema)
        {
            if (updatedCinema == null)
            {
                return BadRequest();
            }

            var existingCinema = cinemaLogic.GetCinemaById(id);
            if (existingCinema == null)
            {
                return NotFound();
            }

            cinemaLogic.UpdateCinema(id, updatedCinema);

            return Ok();
        }
    }
}
