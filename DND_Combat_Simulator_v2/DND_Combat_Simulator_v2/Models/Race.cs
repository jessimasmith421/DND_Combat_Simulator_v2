namespace DND_Combat_Simulator_v2.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string? RaceType { get; set; }
        public int StrengthBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int IntelligenceBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int CharismaBonus { get; set; }
        public string? Size { get; set; }
        public int Speed { get; set; }
        public string? Traits { get; set; }

    }
}
