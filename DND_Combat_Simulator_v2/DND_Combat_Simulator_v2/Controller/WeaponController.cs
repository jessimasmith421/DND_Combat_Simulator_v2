using Microsoft.AspNetCore.Mvc;
using DND_Combat_Simulator_v2.Models;
using DND_Combat_Simulator_v2.DAO;

namespace DND_Combat_Simulator_v2.Controller
{
    [Route("/weapons/")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponDAO weaponDAO;
        
        public WeaponController(IWeaponDAO wdao)
        {
            this.weaponDAO = wdao;
        }

        [HttpGet("{id:int}")]
        public ActionResult GetWeapon(int id)
        {
            Weapon? weapon = weaponDAO.GetWeaponById(id);
            if (weapon == null)
            {
                return NotFound();
            }
            return Ok(weapon);
        }

        [HttpGet()]
        public ActionResult GetWeapons()
        {
            List<Weapon> weapons = weaponDAO.GetAllWeapons();
            if (!weapons.Any())
            {
                return NotFound();
            }
            return Ok(weapons);
        }
    }
}
