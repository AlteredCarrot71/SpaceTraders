using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceTraders
{
    public class Universe
    {
        // All the planets
        private readonly String[] PlanetNames = {"Acamar", "Adahn", "Aldea", "Andevian", "Antedi", "Balosnee",
                "Baratas", "Brax", "Bretel", "Calondia", "Campor", "Capelle", "Carzon", "Castor",
                "Cestus", "Cheron", "Courteney", "Daled", "Damast", "Davlos", "Deneb", "Deneva",
                "Devidia", "Draylon", "Drema", "Endor", "Esmee", "Exo", "Ferris", "Festen", "Fourmi",
                "Frolix", "Gemulon", "Guinifer", "Hades", "Hamlet", "Helena", "Hulst", "Iodine",
                "Iralius", "Janus", "Japori", "Jarada", "Jason", "Kaylon", "Khefka", "Kira", "Klaatu",
                "Klaestron", "Korma", "Kravat", "Krios", "Laertes", "Largo", "Lave", "Ligon", "Lowry",
                "Magrat", "Malcoria", "Melina", "Mentar", "Merik", "Mintaka", "Montor", "Mordan",
                "Myrthe", "Nelvana", "Nix", "Nyle",
                "Odet", "Og", "Omega", "Omphalos", "Orias", "Othello",
                "Parade", "Penthara", "Picard", "Pollux",
                "Quator", "Rakhar", "Ran", "Regulas", "Relva", "Rhymus", "Rochani", "Rubicum", "Rutia",
                "Sarpeidon", "Sefalla", "Seltrice", "Sigma", "Sol", "Somari",
                "Stakoron", "Styris", "Talani", "Tamus", "Tantalos", "Tanuga",
                "Tarchannen", "Terosa", "Thera", "Titan", "Torin", "Triacus",
                "Turkana", "Tyrus",
                "Umberlee", "Utopia",
                "Vadera", "Vagra", "Vandor", "Ventax",
                "Xenon", "Xerxes",
                "Yew", "Yojimbo",
                "Zalkon", "Zuul"};

        // The planets in the game.
        public List<Planet> Planets { get; private set; }

        // Player's current location.
        public Planet CurrentPlanet { get; set; }

        // create universe with specified number of planets.
        private void CreateUniverse()
        {
            Planets = new List<Planet>();

            Random rand = new Random();
            int startingLocation = rand.Next(PlanetNames.Count()) - 1;
            int i = 0;

            foreach ( String planet in PlanetNames )
            {
                int resourceNum = rand.Next(Goods.Values.Count);
                int techLevelNum = rand.Next(Enum.GetValues(typeof(TechLevel)).Length);

                Point point = new Point { Xpos = rand.Next(340) + 5, Ypos = rand.Next(340) + 5 };
                while ( Planets.Exists(x => x.Location.Equals(point)) )
                {
                    point = new Point { Xpos = rand.Next(340) + 5, Ypos = rand.Next(340) + 5 };
                }

                Planet PlanetToAdd = new Planet
                {
                    Name = planet,
                    Resource = Goods.Values[resourceNum],
                    Techlevel = (TechLevel)techLevelNum,
                    Location = point
                };
                Planets.Add(PlanetToAdd);

                if (startingLocation == i)
                    CurrentPlanet = PlanetToAdd;

                i++;
            }
        }

        // Constructor
        public Universe()
        {
            CreateUniverse();
        }
    }
}
