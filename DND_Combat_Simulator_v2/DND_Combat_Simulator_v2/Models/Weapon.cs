namespace DND_Combat_Simulator_v2.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string WeaponType { get; set; }
        public int NumOfDice { get; set; }
        public int DiceType { get; set; }
        public string DamageType { get; set; }

        //potentially could add bools for like "isLight" or "IsTwoHanded", etc
    }
}
