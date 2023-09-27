using HollywoodService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HollywoodAPI.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class EventDetailsController : Controller
    {
        private readonly IEventDetailsService _eventDetailsService;
        public EventDetailsController(IEventDetailsService eventDetailsService)
        {
            _eventDetailsService = eventDetailsService;
        }
        [HttpPost("AddNewEventDetails")]
        public async Task<ActionResult<bool>> AddNewEventDetails([FromBody] AddEventDetail details)
        {
            bool isAdded = false;
            try
            {
                isAdded = await _eventDetailsService.AddNewEventDetail(details);
                return Ok(isAdded);
            }
            catch(Exception)
            {
                return BadRequest(isAdded);
            }
        }
        [HttpGet("GetEventDetailStatuses")]
        public async Task<ActionResult<List<GetEventDetailStatus>>> GetEventDetailStatuses()
        {
            List<GetEventDetailStatus> details = new List<GetEventDetailStatus>();
            try
            {
                details = await _eventDetailsService.GetEventDetailStatuses();
                return Ok(details);
            }
            catch (Exception)
            {
                return NotFound(details);
            }
        }
        [HttpGet("GetEventDetails/{eventId}")]
        public async Task<ActionResult<List<GetEventDetails>>> GetEventDetails(int eventId)
        {
            List<GetEventDetails> details = new List<GetEventDetails>();
            try
            {
                details = await _eventDetailsService.GetEventDetails(eventId);
                return Ok(details);
            }
            catch (Exception)
            {
                return NotFound(details);
            }
        }
        [HttpPut("UpdateEventDetails")]
        public async Task<ActionResult<bool>> UpdateEventDetails([FromBody] UpdateEventDetail details)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = await _eventDetailsService.UpdateEventDetail(details);
                return Ok(isUpdated);
            }
            catch (Exception)
            {
                return BadRequest(isUpdated);
            }
        }
        [HttpDelete("DeleteEventDetails/{eventDetailId}")]
        public async Task<ActionResult<bool>> DeleteEventDetails(int eventDetailId)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = await _eventDetailsService.DeleteEventDetail(eventDetailId);
                return Ok(isUpdated);
            }
            catch (Exception)
            {
                return BadRequest(isUpdated);
            }
        }
    }
}
