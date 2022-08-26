using DND_Combat_Simulator_v2.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DND_Combat_Simulator_v2.DAO
{
    public class CharacterDAO : ICharacterDAO
    {
        private readonly string connectionString;
        private IRaceDAO raceDAO;
        private IWeaponDAO weaponDAO;

        public CharacterDAO(string constr)
        {
            this.connectionString = constr;
            this.raceDAO = new RaceDAO(constr);
            this.weaponDAO = new WeaponDAO(constr);
        }

        public Character GetCharacterById(int id)
        {
            Character character = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,name, race, strength, dexterity,constitution,intelligence,wisdom,charisma, weapon " +
                    "FROM Characters WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                    character = GetCharacterFromDataReader(reader);
            }
            return character;
        }

        public List<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,name, race, strength, dexterity,constitution,intelligence,wisdom,charisma, weapon " +
                    "FROM Characters";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    Character character = GetCharacterFromDataReader(reader);
                    characters.Add(character);
                }
            }
            return characters;
        }

        public Character AddNewCharacter(Character newChar)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Characters(name, race, strength,dexterity,constitution,intelligence,wisdom,charisma,weapon) " +
                    "VALUES (@name, @race,@str,@dex,@con,@int,@wis,@cha,@weapon); " +
                    "SELECT @@IDENTITY";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", newChar.Name);
                cmd.Parameters.AddWithValue("@race", newChar.Race.Id);
                cmd.Parameters.AddWithValue("@str", newChar.Strength);
                cmd.Parameters.AddWithValue("@dex", newChar.Dexterity);
                cmd.Parameters.AddWithValue("@con", newChar.Constitution);
                cmd.Parameters.AddWithValue("@int", newChar.Intelligence);
                cmd.Parameters.AddWithValue("@wis", newChar.Wisdom);
                cmd.Parameters.AddWithValue("@cha", newChar.Charisma);
                cmd.Parameters.AddWithValue("@weapon", newChar.Weapon.Id);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                newChar.Id = id;
            }
            return newChar;
        }

        private Character GetCharacterFromDataReader(SqlDataReader reader)
        {
            Character newChar = new Character();
            newChar.Id = Convert.ToInt32(reader["id"]);
            newChar.Name = Convert.ToString(reader["name"]);
            newChar.Race = raceDAO.GetRaceById(Convert.ToInt32(reader["race"]));
            newChar.Strength = Convert.ToInt32(reader["strength"]);
            newChar.Dexterity = Convert.ToInt32(reader["dexterity"]);
            newChar.Constitution = Convert.ToInt32(reader["constitution"]);
            newChar.Intelligence = Convert.ToInt32(reader["intelligence"]);
            newChar.Wisdom = Convert.ToInt32(reader["wisdom"]);
            newChar.Charisma = Convert.ToInt32(reader["charisma"]);
            newChar.Weapon = weaponDAO.GetWeaponById(Convert.ToInt32(reader["weapon"]));
            return newChar;
        }
    }
}
