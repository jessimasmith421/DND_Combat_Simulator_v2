using Microsoft.AspNetCore.Mvc;
using DND_Combat_Simulator_v2.Models;
using DND_Combat_Simulator_v2.DAO;

namespace DND_Combat_Simulator_v2.Controller
{
    [Route("/characters/")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterDAO characterDAO;
        public CharacterController(ICharacterDAO cdao)
        {
            this.characterDAO = cdao;
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCharacter(int id)
        {
            Character? character = characterDAO.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpGet()]
        public ActionResult GetCharacters()
        {
            List<Character> characters = characterDAO.GetAllCharacters();
            if (!characters.Any())
            {
                return NotFound();
            }
            return Ok(characters);
        }

        [HttpPost()]
        public ActionResult AddCharacter(Character newChar)
        {
            newChar = characterDAO.AddNewCharacter(newChar);
            
            return Created("/characters/" + newChar.Id, newChar);
        }
    }
}
