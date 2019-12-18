using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Model;
using CTrackAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CTrackAPI.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;

        }

        [HttpGet("GetPeople")]
        public IActionResult Create([FromBody]ChittiDto chitti)
        {
            if (chitti == null)
                return BadRequest(new { message = "Bad request" });

            try
            {

                _peopleRepository.GetPeople(chitti);
                return Ok(chitti);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}