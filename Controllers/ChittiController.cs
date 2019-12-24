using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTrackAPI.Entities;
using CTrackAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ChittiController : ControllerBase
{

    private  IChittiRepository _chittiRepository;

    public ChittiController(IChittiRepository chittiRepository)
    {
        _chittiRepository = chittiRepository;

    }


    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        return Ok(_chittiRepository.Get(id));
    }

    // GET api/values/5
    [HttpGet("GetUserChitti")]
    public IActionResult GetUserChitti(long userid)
    {
        return Ok(_chittiRepository.GetChittiByUserId(userid));
    }

    [HttpGet("GetAdminChitti")]
    public IActionResult GetAdminChitti(long userid)
    {
        return Ok(_chittiRepository.GetAdminChitti(userid));
    }

    // POST api/values
    [HttpPost("create")]
    public IActionResult Create([FromBody]Chitti chitti)
    {
        if (chitti == null)
            return BadRequest(new { message = "Bad request" });

        try
        {
            chitti.EndDate = chitti.StartDate.AddMonths(chitti.NoOfMonths);
            chitti.CreatedOn = DateTime.Now;
            chitti.UpdatedOn = DateTime.Now;
            _chittiRepository.Create(chitti);
            return Ok(chitti);
        }
        catch (Exception ex)
        {
            // return error message if there was an exception
            return BadRequest(new { message = ex.Message });
        }
    }
    // POST api/values
    [HttpPut("update")]
    public IActionResult update([FromBody]Chitti chitti)
    {
        if (chitti == null)
            return BadRequest(new { message = "Bad request" });

        try
        {
            chitti.EndDate = chitti.StartDate.AddMonths(chitti.NoOfMonths);            
            chitti.UpdatedOn = DateTime.Now;
            _chittiRepository.Update(chitti);
            return Ok(chitti);
        }
        catch (Exception ex)
        {
            // return error message if there was an exception
            return BadRequest(new { message = ex.Message });
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _chittiRepository.Delete(id);
        return;
    }
}