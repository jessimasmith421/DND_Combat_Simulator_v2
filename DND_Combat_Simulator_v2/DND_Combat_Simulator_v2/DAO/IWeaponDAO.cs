using DND_Combat_Simulator_v2.Models;
using System.Collections.Generic;


namespace DND_Combat_Simulator_v2.DAO
{
    public interface IWeaponDAO
    {
        Weapon? GetWeaponById(int id);
        List<Weapon> GetAllWeapons();
    }
}
