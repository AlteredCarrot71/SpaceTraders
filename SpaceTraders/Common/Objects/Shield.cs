// A class representing shields for use in combat.
namespace SpaceTraders
{
    public class Shield : Abstract.Item
    {
        public TechLevel MinTechLevel { get; set; }
        public int SkillModifier { get; set; }

        public Shield() { }
    }
}
