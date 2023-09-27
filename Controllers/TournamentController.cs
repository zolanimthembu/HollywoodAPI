using HollywoodService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HollywoodAPI.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService) 
        {
            _tournamentService = tournamentService;
        }
        
        [HttpPost("AddNewTournament")]
        public async Task<ActionResult<bool>> AddNewTounament([FromBody] AddTournament tournament)
        {
            bool success = false;
            try
            {
                success = await _tournamentService.AddNewTournament(tournament);
                return Ok(success);
            }catch (Exception)
            {
                return BadRequest(success);
            }
        }
        [HttpGet("GetTournaments")]
        public async Task<ActionResult<List<GetTournaments>>> GetTournaments()
        {
            List<GetTournaments>  tournaments = new List<GetTournaments>();
            try
            {
                tournaments = await _tournamentService.GetTournaments();
                return Ok(tournaments);
            }
            catch (Exception )
            {
                return NotFound(tournaments);
            }
        }
        [HttpPut("UpdateTournament")]
        public async Task<ActionResult<bool>> UpdateTournament([FromBody] UpdateTournament tournament)
        {
            bool updated = false;
            try
            {
                updated = await _tournamentService.UpdateTournament(tournament);
                return Ok(updated);
            }
            catch (Exception)
            {
                return BadRequest(updated);
            }
        }
        [HttpDelete("DeleteTournament/{tournamentId}")]
        public async Task<ActionResult<bool>> DeleteTournament(int tournamentId)
        {
            bool deleted = false;
            try
            {
                deleted = await _tournamentService.DeleteTournament(tournamentId);
                return Ok(deleted);
            }
            catch (Exception)
            {
                return BadRequest(deleted);
            }
        }
    }
}
