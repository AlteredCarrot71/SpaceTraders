using System;

namespace SpaceTraders
{
    // A planet in a SolarSystem. It has a tech level, resources, and a name.
    public class Planet
    {
        // Name of this planet.
        public String Name { get; set; }
        // Tech level for this planet.
        public TechLevel Techlevel { get; set; }
        // Resource for this planet.
        public Good Resource { get; set; }
        // Planet location
        public Point Location { get; set; }
        // Marketplace specific to this planet.
        public Marketplace Marketplace { get; set; }
        // Shipyard specific to this planet.
        public Shipyard Shipyard { get; set; }

        // Constructor for Planet.
        public Planet() { }

        // This method initializes the marketplace on a planet. It should be called after the player
        // visits the planet. It creates a random supply of various goods
        public Marketplace EnterMarket(Player player)
        {
            Marketplace = new Marketplace();
            return Marketplace;
        }

        // Initializes a Shipyard for a Planet.
        public Shipyard EnterShipyard(Player player)
        {
            Shipyard = new Shipyard();
            return Shipyard;
        }

        // Determines if a Planet has as shipyard (techLevel is HI_TECH).
        public bool HasShipYard()
        {
            return Techlevel == TechLevel.HI_TECH;
        }

        public String GetInfo()
        {
            return "Planet Name: " + Name + 
                   "\nResources: " + Resource.Name +
                   "\nTech: " + Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("TechLevel/" + Techlevel.ToString() + "/Name");
        }
    }
}
