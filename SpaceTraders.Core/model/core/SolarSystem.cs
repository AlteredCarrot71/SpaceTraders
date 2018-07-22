using System;
using System.Collections.Generic;
using System.Text;
/**
 * A SolarSystem has a position in the universe and contains planets, which have
 * specific resources and tech levels.
 *
 * @author Nick
 *
 */

namespace SpaceTraders
{
    public class SolarSystem
    {

        /**
         * Name of solar system.
         */
        private String name;
        /**
         * position of solar system.
         */
        private Point pos;
        /**
         * Planets in a solar system.
         */
        private IList<Planet> planets;

        /**
         * Constructor for solar systems.
         *
         * @param nameArg
         *        the name of the solar system
         * @param posArg
         *        the position of the solar system
         * @param varPlanets
         *        the planets in the solar system
         */
        public SolarSystem(String nameArg, Point posArg, Planet planet)
        {
            this.name = nameArg;
            this.pos = posArg;
            planets = new List<Planet>();
            planets.Add(planet);
        }

        /**
         * Returns distance between 2 SolarSystems.
         *
         * @param other
         *        a SolarSystem
         * @return int distance between 2 SolarSystems
         */
        public int distance(SolarSystem other)
        {
            return pos.Distance(other.getPosition());
        }

        /**
         * Gets position of planet.
         *
         * @return position
         */
        public Point getPosition()
        {
            return pos;
        }


        public String toString()
        {
            StringBuilder planetString = new StringBuilder();

            foreach (Planet p in planets)
            {

                planetString.Append(" ");
                planetString.Append(p.GetInfo());

            }

            return "Solar System Name: " + name + "\nPoint: " + pos.ToString() + "\n"
                            + planetString.ToString();

        }

        /**
         * Returns list of planets in solar system.
         *
         * @return list of planets
         */
        public IList<Planet> getPlanets()
        {
            return planets;
        }
    }
}
