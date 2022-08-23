using Microsoft.AspNetCore.Mvc;
using DND_Combat_Simulator_v2.Models;
using DND_Combat_Simulator_v2.DAO;

namespace DND_Combat_Simulator_v2.Controller
{
    [Route("/races/")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceDAO raceDAO;

        public RaceController(IRaceDAO rdao)
        {
            this.raceDAO = rdao;
        }

        [HttpGet("{id}")]
        public ActionResult getRace(int id)
        {
            Race race = raceDAO.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }
    }
}
