using DND_Combat_Simulator_v2.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DND_Combat_Simulator_v2.DAO
{
    public class RaceDAO : IRaceDAO
    {
        private readonly string connectionString;
        public RaceDAO(string constr)
        {
            this.connectionString = constr;
        }

        public Race GetRaceById(int id)
        {
            Race race = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,race,strength_bonus,dexterity_bonus,constitution_bonus,intelligence_bonus,wisdom_bonus,charisma_bonus,size,speed,traits " +
                    "FROM Races WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                    race = GetRaceFromDataReader(reader);
            }
            return race;
        }
        public List<Race> GetRaces()
        {
            List<Race> races = new List<Race>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,race,strength_bonus,dexterity_bonus,constitution_bonus,intelligence_bonus,wisdom_bonus,charisma_bonus,size,speed,traits " +
                    "FROM Races";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    Race race = GetRaceFromDataReader(reader);

                    races.Add(race);
                }

            }
            return races;

        }

        private static Race GetRaceFromDataReader(SqlDataReader reader)
        {
            return new Race()
            {

                Id = Convert.ToInt32(reader["id"]),
                RaceType = Convert.ToString(reader["race"]),
                StrengthBonus = Convert.ToInt32(reader["strength_bonus"]),
                DexterityBonus = Convert.ToInt32(reader["dexterity_bonus"]),
                ConstitutionBonus = Convert.ToInt32(reader["constitution_bonus"]),
                IntelligenceBonus = Convert.ToInt32(reader["intelligence_bonus"]),
                WisdomBonus = Convert.ToInt32(reader["wisdom_bonus"]),
                CharismaBonus = Convert.ToInt32(reader["charisma_bonus"]),
                Size = Convert.ToString(reader["size"]),
                Speed = Convert.ToInt32(reader["speed"]),
                Traits = Convert.ToString(reader["traits"]),

            };
        }

    }
}
