// A class representing weapons for use in combat.
namespace SpaceTraders
{
    public class Weapon : Abstract.Item
    {
        public TechLevel MinTechLevel { get; set; }
        public int SkillModifier { get; set; }

        public Weapon() { }
    }
}
