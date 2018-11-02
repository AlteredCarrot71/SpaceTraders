using System;
using System.Collections.Generic;
using System.Text;

// A SolarSystem has a position in the universe and contains planets, which have
// specific resources and tech levels.
namespace SpaceTraders
{
    public class SolarSystem
    {
        // Name of solar system.
        public String Name { get; private set; }
        // position of solar system.
        public Point Position { get; private set; }
        // Planets in a solar system.
        public List<Planet> Planets { get; private set; } = new List<Planet>();

        // Constructor for solar systems.
        public SolarSystem(String nameArg, Point posArg, Planet planet)
        {
            Name = nameArg;
            Position = posArg;
            Planets.Add(planet);
        }

        // Returns distance between 2 SolarSystems.
        public int Distance(SolarSystem other)
        {
            return Position.Distance(other.Position);
        }

        public String toString()
        {
            StringBuilder planetString = new StringBuilder();

            foreach (Planet p in Planets)
            {
                planetString.Append(" ");
                planetString.Append(p.GetInfo());
            }

            return "Solar System Name: " + Name + "\nPoint: " + Position.ToString() + "\n"
                            + planetString.ToString();
        }
    }
}
