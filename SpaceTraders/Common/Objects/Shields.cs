using System;

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
}
