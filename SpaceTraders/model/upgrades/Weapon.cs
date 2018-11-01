using System;

namespace SpaceTraders
{
    public static class Weapons
    {
        // A standard laser.
        public static readonly Weapon PULSE_LASER = new Weapon
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Pulse/Name"),
            Price = 500
        };
        // A better laser.
        public static readonly Weapon BEAM_LASER = new Weapon
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Beam/Name"),
            Price = 1000
        };
        // The best laser.
        public static readonly Weapon MILITARY_LASER = new Weapon
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Weapon/Military/Name"),
            Price = 1500
        };
    }

    public class Weapon
    {
        public String Name { get; set; }
        public int Price { get; set; }

        public Weapon() { }
    }
}
