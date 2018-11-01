using System;

// A class representing shields for use in combat.
namespace SpaceTraders
{
    public static class Shields
    {
        // A basic shield.
        public static readonly Shield ENERGY_SHIELD = new Shield
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Shield/Energy/Name"),
            Price = 500
        };
        // A premium shield.
        public static readonly Shield REFLECTIVE_SHIELD = new Shield
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Shield/Reflective/Name"),
            Price = 1000
        };
    }

    public class Shield
    {
        public String Name { get; set; }
        public int Price { get; set; }

        public Shield() { }
    }
}
