using System;

namespace SpaceTraders
{
    // A planet in a SolarSystem. It has a tech level, resources, and a name.
    public class Planet
    {
        // Name of this planet.
        public String Name { get; private set; }
        // Tech level for this planet.
        public TechLevel Techlevel { get; private set; }
        // Resource for this planet.
        public Good Resource { get; private set; }
        // Marketplace specific to this planet.
        public Marketplace Marketplace { get; private set; }
        // Shipyard specific to this planet.
        public Shipyard Shipyard { get; private set; }

        // Constructor for Planet.
        public Planet(String nameArg, Good resourceArg, TechLevel techArg)
        {
            Name = nameArg;
            Resource = resourceArg;
            Techlevel = techArg;
        }

        // This method initializes the marketplace on a planet. It should be called after the player
        // visits the planet. It creates a random supply of various goods
        public Marketplace EnterMarket(Player player)
        {
            Marketplace = new Marketplace(Techlevel, player);
            return Marketplace;
        }

        // Initializes a Shipyard for a Planet.
        public Shipyard EnterShipyard(Player player)
        {
            Shipyard = new Shipyard(Marketplace, player);
            return Shipyard;
        }

        // Determines if a Planet has as shipyard (techLevel is HI_TECH).
        public bool HasShipYard()
        {
            return Techlevel == TechLevel.HI_TECH;
        }

        public String GetInfo()
        {
            return "Planet Name: " + Name + "\n\tResources: " + Resource
                            + "\n\tTech: " + Techlevel;
        }
    }
}
