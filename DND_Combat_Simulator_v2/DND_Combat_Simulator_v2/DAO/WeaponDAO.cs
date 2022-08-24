using DND_Combat_Simulator_v2.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DND_Combat_Simulator_v2.DAO
{
    public class WeaponDAO : IWeaponDAO
    {
        private readonly string connectionString;
        public WeaponDAO(string constr)
        {
            this.connectionString = constr;
        }

        public Weapon GetWeaponById(int id)
        {
            Weapon weapon = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,weapon,type_of_dice,num_of_dice,damage_type FROM Weapons WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                    weapon = GetWeaponFromDataReader(reader);
            }
            return weapon;
        }
        public List<Weapon> GetAllWeapons()
        {
            List<Weapon> weapons = new List<Weapon>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id,weapon,type_of_dice,num_of_dice,damage_type FROM Weapons";
                SqlCommand cmd = new SqlCommand(sql, conn);
       
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    Weapon weapon = new Weapon();
                    weapon = GetWeaponFromDataReader(reader);
                    weapons.Add(weapon);
                }
            }
            return weapons;
        }

        private static Weapon GetWeaponFromDataReader(SqlDataReader reader)
        {
            return new Weapon()
            {
                Id = Convert.ToInt32(reader["id"]),
                WeaponType = Convert.ToString(reader["weapon"]),
                DiceType = Convert.ToInt32(reader["type_of_dice"]),
                NumOfDice = Convert.ToInt32(reader["num_of_dice"]),
                DamageType = Convert.ToString(reader["damage_type"])
            };
        }

    }
}
