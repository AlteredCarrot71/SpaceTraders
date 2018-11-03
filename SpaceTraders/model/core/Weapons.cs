using Windows.ApplicationModel.Resources;

namespace SpaceTraders
{
    public static class Weapons
    {
        // A standard laser.
        public static readonly Weapon PULSE_LASER = new Weapon
        {
            Name = ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Pulse/Name"),
            Price = 5000,
            MinTechLevel = TechLevel.INDUSTRIAL,
            SkillModifier = 1
        };

        // A better laser.
        public static readonly Weapon BEAM_LASER = new Weapon
        {
            Name = ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Beam/Name"),
            Price = 10000,
            MinTechLevel = TechLevel.POST_INDUSTRIAL,
            SkillModifier = 2
        };

        // The best laser.
        public static readonly Weapon MILITARY_LASER = new Weapon
        {
            Name = ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Military/Name"),
            Price = 20000,
            MinTechLevel = TechLevel.HI_TECH,
            SkillModifier = 4
        };
    }
}
