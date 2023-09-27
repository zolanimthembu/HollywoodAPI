using HollywoodService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HollywoodAPI.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost("AddNewEvent")]
        public async Task<ActionResult<bool>> AddNewEvent([FromBody] AddEvent newEvent)
        {
            bool isAdded = false;
            try
            {
                isAdded = await _eventService.AddNewEvent(newEvent);
                return Ok(isAdded);
            }
            catch (Exception)
            {
                return BadRequest(isAdded);
            }

        }
        [HttpGet("GetEvents/{tournamentId}")]
        public async Task<ActionResult<List<GetEvents>>> GetEvents(int tournamentId)
        {
            List<GetEvents> events =  new List<GetEvents>();
            try
            {
                events = await _eventService.GetEventsByTournamentId(tournamentId);
                return Ok(events);
            }
            catch (Exception)
            {
                return BadRequest(events);
            }

        }
        [HttpPut("UpdateEvent")]
        public async Task<ActionResult<bool>> UpdateEvent([FromBody] UpdateEvent UpdateEvent)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = await _eventService.UpdateEvent(UpdateEvent);
                return Ok(isUpdated);
            }
            catch (Exception)
            {
                return BadRequest(isUpdated);
            }
        }
        [HttpDelete("DeleteEvent/{eventId}")]
        public async Task<ActionResult<bool>> UpdateEvent(int eventId)
        {
            bool deleted = false;
            try
            {
                deleted = await _eventService.DeleteEvent(eventId);
                return Ok(deleted);
            }
            catch (Exception)
            {
                return BadRequest(deleted);
            }
        }
    }
}
