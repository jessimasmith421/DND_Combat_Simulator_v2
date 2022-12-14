using System.ComponentModel.DataAnnotations;

namespace DND_Combat_Simulator_v2.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public Race? Race { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        [Required]
        public Weapon? Weapon { get; set; }
    }
}
