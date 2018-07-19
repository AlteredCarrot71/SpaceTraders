using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

/**
 * Singleton game monitor. The game model will control the passing of turns and
 * random events
 *
 * @author ngraves3
 *
 */
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

public class GameInstance {

    /**
     * Reference to the Singleton GameInstance.
     */
    private static readonly GameInstance instance = new GameInstance();
    /**
     * The player playing.
     */
    private Player player;
    /**
     * The solar systems in the game.
     */
    private ISet<SolarSystem> solarSystems = new HashSet<SolarSystem>();
    /**
     * The planets in the game.
     */
    private ISet<Planet> planets = new HashSet<Planet>();
    /**
     * The points which are the locations of the solar systems.
     */
    private ISet<Point> points = new HashSet<Point>();
    /**
     * Player's current location.
     */
    private Planet currentPlanet;
    /**
     * Players current location.
     */
    private SolarSystem currentSolarSystem;
    /**
     * Flag to check if game was created.
     */
    private bool saveDirectoryCreated = false;
    /**
     * All the planet names. May or may not use all of them.
     */
    private String[] planetNames = {"Acamar", "Adahn", "Aldea", "Andevian", "Antedi", "Balosnee",
        "Baratas", "Brax", "Bretel", "Calondia", "Campor", "Capelle", "Carzon", "Castor",
        "Cestus", "Cheron", "Courteney", "Daled", "Damast", "Davlos", "Deneb", "Deneva",
        "Devidia", "Draylon", "Drema", "Endor", "Esmee", "Exo", "Ferris", "Festen", "Fourmi",
        "Frolix", "Gemulon", "Guinifer", "Hades", "Hamlet", "Helena", "Hulst", "Iodine",
        "Iralius", "Janus", "Japori", "Jarada", "Jason", "Kaylon", "Khefka", "Kira", "Klaatu",
        "Klaestron", "Korma", "Kravat", "Krios", "Laertes", "Largo", "Lave", "Ligon", "Lowry",
        "Magrat", "Malcoria", "Melina", "Mentar", "Merik", "Mintaka", "Montor", "Mordan",
        "Myrthe"};
    /**
     * Solar system names for the game. May or may not use all.
     */
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

    /**
     * Private constructor for Singleton. Prevents others from accessing
     */
    private GameInstance() { //private constructor for singleton
    }

    /**
     * Gets the only GameInstance.
     *
     * @return the sole GameInstance
     */
    public static GameInstance getInstance() {
        return instance;
    }

    /**
     * Creates a universe with number of planets equal to the length of our default list of planet
     * names.
     */
    public void createUniverse() {
        createUniverse(Math.Min(planetNames.Length, solarSystemNames.Length) - 1);
    }

    /**
     * create universe with specified number of planets.
     *
     * @param number
     *        of planets
     */
    public void createUniverse(int number) {
        /**
        if (number >= planetNames.length || number >= solarSystemNames.length) {
            throw new IllegalArgumentException("Number is bigger than planet names");
        }
        if (number < 1) {
            throw new IllegalArgumentException("Number must be positive");
        }
        **/
        solarSystems.Clear();
        planets.Clear();
        points.Clear();
        Random rand = new Random();
        int startingLocation = rand.Next(number) - 1;
        int planetCount = 0;
        int solarSystemCount = 0;
        for (int i = 0; i < number; i++) {

            int resourceNum =  rand.Next(Goods.Values.Count);
            int techLevelNum = rand.Next(Enum.GetValues( typeof(TechLevel)).Length);

            Point point = new Point(rand.Next(340) + 5, rand.Next(340) + 5);
            while (points.Contains(point)) {
                point = new Point(rand.Next(340) + 5, rand.Next(340) + 5);
            }
            points.Add(point);
            Planet planet =
                    new Planet(planetNames[planetCount],
                            Goods.Values[resourceNum],
                            (TechLevel) techLevelNum);
            planets.Add(planet);

            planetCount++;
            SolarSystem solarsystem =
                    new SolarSystem(solarSystemNames[solarSystemCount],
                            point, planet);
            solarSystemCount++;

            solarSystems.Add(solarsystem);

            if (startingLocation == i) {
                setCurrentPlanet(planet);
                setCurrentSolarSystem(solarsystem);
            }

        }

    }

    /**
     * Gets the player's current planet.
     *
     * @return player's current planet
     */
    public Planet getCurrentPlanet() {
        return currentPlanet;
    }

    /**
     * Sets the player's location to a planet.
     *
     * @param destination
     *        the planet to go to
     */
    public void setCurrentPlanet(Planet destination) {
        this.currentPlanet = destination;
    }

    /**
     * Returns the player for the instance of this game.
     *
     * @return the Player
     */
    public Player getPlayer() {
        return player;
    }

    /**
     * Sets a player for this game instance.
     *
     * @param data
     *        the Player to use for this instance
     */
    public void setPlayer(Player data) {
        player = data;
    }

    /**
     * Returns the solar system the player is in.
     *
     * @return the current solar system
     */
    public SolarSystem getCurrentSolarSystem() {
        return currentSolarSystem;
    }

    /**
     * Sets the current solar system to whatever is passed in.
     *
     * @param destination
     *        the new solar system
     */
    public void setCurrentSolarSystem(SolarSystem destination) {
        currentSolarSystem = destination;
    }

    /**
     * Returns a Set of the solar systems.
     *
     * @return Set of solar systems
     */
    public ISet<SolarSystem> getSolarSystems() {
        return solarSystems;
    }

    /**
     * Sets the solar systems to the given set.
     *
     * @param solarSystemSet
     *        the set of solarSystems to use
     */
    public void setSolarSystems(ISet<SolarSystem> solarSystemSet) {
        this.solarSystems = solarSystemSet;
    }

    /**
     * Returns a set of the planets.
     *
     * @return set of planets
     */
    public ISet<Planet> getPlanets() {
        return planets;
    }

    /**
     * Sets the planet to the Set<Planet> arg.
     *
     * @param planetSet
     *        the planets to use as set of planets
     */
    public void setPlanets(ISet<Planet> planetSet) {
        this.planets = planetSet;
    }

    
    public String toString() {

        StringBuilder gameString = new StringBuilder();
        gameString.Append("SOLAR: ");

        foreach (SolarSystem s in solarSystems) {

            gameString.Append(" ").Append(s.toString());

        }
        String term = "\n\n";
        gameString.Append(term).Append(" Current Player: ").Append(player.toString()).Append(term);
        gameString.Append("Current Planet: ").Append(currentPlanet.toString()).Append(term);
        gameString.Append("Current SolarSystem: ").Append(currentSolarSystem.toString()).Append(term);


        return gameString.ToString();
    }

    /**
     * Returns the set of points.
     *
     * @return the set of points
     */
    public ISet<Point> getPoints() {
        return points;
    }
}
