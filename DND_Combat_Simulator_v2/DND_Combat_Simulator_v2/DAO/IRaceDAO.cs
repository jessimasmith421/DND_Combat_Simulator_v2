using DND_Combat_Simulator_v2.Models;
using System.Collections.Generic;

namespace DND_Combat_Simulator_v2.DAO
{
    public interface IRaceDAO
    {
        Race? GetRaceById(int id);
        List<Race> GetAllRaces();
    }
}
