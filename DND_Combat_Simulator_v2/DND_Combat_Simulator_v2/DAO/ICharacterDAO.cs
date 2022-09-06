using DND_Combat_Simulator_v2.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;


namespace DND_Combat_Simulator_v2.DAO
{
    public interface ICharacterDAO
    {
        Character? GetCharacterById(int id);
        List<Character> GetAllCharacters();

        Character AddNewCharacter(Character newChar);
    }
}
