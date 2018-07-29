using System;
using System.Collections.Generic;
using System.Text;

// Singleton game monitor. The game model will control the passing of turns and
// random events

namespace SpaceTraders
{
    public class GameInstance
    {
        // Reference to the Singleton GameInstance.
        private static readonly Lazy<GameInstance> lazy = new Lazy<GameInstance>(() => new GameInstance());

        public static GameInstance Instance
        {
            get { return lazy.Value; }
        }
        
        private GameInstance()
        {
            //
        }

        // Player
        public Player Player { get; set; }
        
        // The solar systems in the game.
        private ISet<SolarSystem> solarSystems = new HashSet<SolarSystem>();

        // The planets in the game.
        public List<Planet> Planets { get; private set; }
        
        // Player's current location.
        public Planet CurrentPlanet { get; set; }

        // Players current location.
        private SolarSystem currentSolarSystem;
        
        // All the planet names. May or may not use all of them.
        private String[] planetNames = {"Acamar", "Adahn", "Aldea", "Andevian", "Antedi", "Balosnee",
            "Baratas", "Brax", "Bretel", "Calondia", "Campor", "Capelle", "Carzon", "Castor",
            "Cestus", "Cheron", "Courteney", "Daled", "Damast", "Davlos", "Deneb", "Deneva",
            "Devidia", "Draylon", "Drema", "Endor", "Esmee", "Exo", "Ferris", "Festen", "Fourmi",
            "Frolix", "Gemulon", "Guinifer", "Hades", "Hamlet", "Helena", "Hulst", "Iodine",
            "Iralius", "Janus", "Japori", "Jarada", "Jason", "Kaylon", "Khefka", "Kira", "Klaatu",
            "Klaestron", "Korma", "Kravat", "Krios", "Laertes", "Largo", "Lave", "Ligon", "Lowry",
            "Magrat", "Malcoria", "Melina", "Mentar", "Merik", "Mintaka", "Montor", "Mordan",
            "Myrthe"};
        // Solar system names for the game. May or may not use all.
        private String[] solarSystemNames = {"Nelvana", "Nix", "Nyle",
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

        // Creates a universe with number of planets equal to the length of our default list of planet names.
        public void createUniverse()
        {
            createUniverse(Math.Min(planetNames.Length, solarSystemNames.Length) - 1);
        }

        // create universe with specified number of planets.
        public void createUniverse(int number)
        {
            Planets = new List<Planet>();

            solarSystems.Clear();
            Random rand = new Random();
            int startingLocation = rand.Next(number) - 1;
            int planetCount = 0;
            int solarSystemCount = 0;
            for (int i = 0; i < number; i++)
            {
                int resourceNum = rand.Next(Goods.Values.Count);
                int techLevelNum = rand.Next(Enum.GetValues(typeof(TechLevel)).Length);

                Point point = new Point(rand.Next(340) + 5, rand.Next(340) + 5);
                while ( Planets.Exists(x => x.Location.Equals(point)) )
                {
                    point = new Point(rand.Next(340) + 5, rand.Next(340) + 5);
                }

                Planet planet = new Planet( planetNames[planetCount],
                                            Goods.Values[resourceNum],
                                            (TechLevel)techLevelNum, 
                                            point
                                          );
                Planets.Add(planet);

                planetCount++;
                SolarSystem solarsystem =
                        new SolarSystem(solarSystemNames[solarSystemCount],
                                point, planet);
                solarSystemCount++;

                solarSystems.Add(solarsystem);

                if (startingLocation == i)
                {
                    CurrentPlanet = planet;
                    setCurrentSolarSystem(solarsystem);
                }

            }
        }

        // Returns the solar system the player is in.
        public SolarSystem getCurrentSolarSystem()
        {
            return currentSolarSystem;
        }

        // Sets the current solar system to whatever is passed in.
        public void setCurrentSolarSystem(SolarSystem destination)
        {
            currentSolarSystem = destination;
        }

        // Returns a Set of the solar systems.
        public ISet<SolarSystem> getSolarSystems()
        {
            return solarSystems;
        }

        public String toString()
        {

            StringBuilder gameString = new StringBuilder();
            gameString.Append("SOLAR: ");

            foreach (SolarSystem s in solarSystems)
            {
                gameString.Append(" ").Append(s.toString());
            }

            String term = "\n\n";
            gameString.Append(term).Append(" Current Player: ").Append(Player.GetInfo()).Append(term);
            gameString.Append("Current Planet: ").Append(CurrentPlanet.GetInfo()).Append(term);
            gameString.Append("Current SolarSystem: ").Append(currentSolarSystem.toString()).Append(term);

            return gameString.ToString();
        }
    }
}
