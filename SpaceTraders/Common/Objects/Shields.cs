using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

namespace SpaceTraders
{
    public static class Shields
    {
        // A basic shield.
        public static readonly Shield ENERGY_SHIELD = new Shield
        {
            Name = ResourceLoader.GetForViewIndependentUse().GetString("Shield/Energy/Name"),
            Price = 500,
            MinTechLevel = TechLevel.INDUSTRIAL,
            SkillModifier = 1
        };

        // A premium shield.
        public static readonly Shield REFLECTIVE_SHIELD = new Shield
        {
            Name = ResourceLoader.GetForViewIndependentUse().GetString("Shield/Reflective/Name"),
            Price = 1000,
            MinTechLevel = TechLevel.HI_TECH,
            SkillModifier = 3
        };

        public static readonly List<Shield> Values = new List<Shield> { ENERGY_SHIELD, REFLECTIVE_SHIELD };
    }
}
