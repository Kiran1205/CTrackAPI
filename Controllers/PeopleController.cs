using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Model;
using CTrackAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;

        }

        [HttpPost("getPeople")]
        public IActionResult GetPeople([FromBody]ChittiDto chitti)
        {
            if (chitti == null)
                return BadRequest(new { message = "Bad request" });

            try
            {

                var listofPeople = _peopleRepository.GetPeople(chitti);
                return Ok(listofPeople);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getPeopleList")]
        public IActionResult GetPeopleList(long chittiPID)
        {
                      try
            {

                var listofPeople = _peopleRepository.GetPeopleList(chittiPID);
                return Ok(listofPeople);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST api/values
        [HttpPost("create")]
        public IActionResult Create([FromBody]People people)
        {
            if (people == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                people.CreatedOn = DateTime.Now;
                people.UpdatedOn = DateTime.Now;
                _peopleRepository.Create(people);
                return Ok(people);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _peopleRepository.Delete(id);
            return;
        }


    }
}