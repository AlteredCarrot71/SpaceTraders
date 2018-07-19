using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/**
 * This class represents a Ship object. A ship contains cargo, weapons, shields,
 * gadgets, and crew. It also has fuel, a purchasing price, and NPC disposition
 * modifiers. Converted from enum to class so object would be serialized
 * correctly
 *
 *
 * It might be a good idea to use a custom linked list with a maximum size
 * rather than arrays to store cargo
 *
 * @author ngraves3
 *
 */
public class Ship {

    /**
     * makes a flea.
     *
     * @return a flea
     */
    public static Ship flea() {
        return new Ship("Flea", 10, 0, 0, 0, 1, 500, 1, 2000, 5, 25, -1, -1, 0);

    }

    /**
     * Makes a gnat.
     *
     * @return a gnat
     */
    public static Ship gnat() {
        return new Ship("Gnat", 15, 1, 0, 1, 1, 140, 2, 10000, 50, 100, 0, 0, 1);
    }

    /**
     * Makes a firefly.
     *
     * @return a firely
     */
    public static Ship firefly() {
        return new Ship("Firefly", 20, 1, 1, 1, 1, 170, 3, 25000, 75, 100, 0,
                        0, 1);
    }

    /**
     * makes a mosquito.
     *
     * @return a mosquito
     */
    public static Ship mosquito() {
        return new Ship("Mosquito", 15, 2, 1, 1, 1, 130, 5, 30000, 100, 100, 0,
                        1, 1);
    }

    /**
     * Makes a bumblebee.
     *
     * @return a bumblebee
     */
    public static Ship bumblebee() {
        return new Ship("Bumblebee", 25, 1, 2, 2, 2, 150, 7, 60000, 125, 100,
                        0, 1, 2);
    }

    /**
     * Factory method to make Ships.
     *
     * @param shipName
     *        the name of the ship to make
     * @return the ship created, else null
     */
    public static Ship shipFactory(String shipName)
    {

        String name = shipName.ToLower();

        if (name.Equals("flea")) {
            return Ship.flea();
        } else if (name.Equals("gnat")) {
            return Ship.gnat();
        } else if (name.Equals("firefly")) {
            return Ship.firefly();
        } else if (name.Equals("mosquito")) {
            return Ship.mosquito();
        } else if (name.Equals("bumblebee")) {
            return Ship.bumblebee();
        } else {
            return null;
        }
    }

    /**
     * ship cargo.
     */
    private PresizedList<Good> cargo;

    /**
     * ship weapons.
     */
    private PresizedList<Weap> weapons;

    /**
     * Ship shields.
     */
    private PresizedList<Shie> shields;

    /**
     * Ship gadgets.
     */
    private PresizedList<AbstractGadget> gadgets;

    /**
     * Ship crew.
     */
    private PresizedList<Crew> crew;

    /**
     * Maximum fuel this ship can hold.
     */
    private int maxFuel;

    /**
     * whether can ship be seen by others during travel.
     */
    private bool isVisible;

    /**
     * the current amount of fuel.
     */
    private int currentFuel;
    /**
     * Name of ship.
     */
    private String name;

    /**
     * Min tech level for ship to be sold in shipyard.
     */
    private TechLevel minTechLevel; // use for validation purposes

    /**
     * cost per unit of fuel.
     */
    private int fuelCost;

    /**
     * base price of ship.
     */
    private int price;

    /**
     * Bounty on ship.
     */
    private int bounty;

    /**
     * hull strength for fights.
     */
    private int hullStrength;

    /**
     * Police disposition towards ship.
     */
    private int policeAggression;

    /**
     * Pirate aggression towards ship.
     */
    private int pirateAggression;

    /**
     * Size of ship.
     */
    private int size;

    /**
     * Private ship constructor. Makes new ships through methods.
     *
     * @param nameArg
     *        name of ship
     * @param cargoSize
     *        size of cargo
     * @param weaponSize
     *        num of weapons
     * @param shieldSize
     *        num of shields
     * @param gadgetSize
     *        num of gadgets
     * @param crewSize
     *        num of crew
     * @param maxFuelArg
     *        maximum amount of fuel for ship
     * @param fuelCostArg
     *        cost per price of fuel
     * @param priceArg
     *        base prices of ship
     * @param bountyArg
     *        bounty if caught
     * @param hullStrengthArg
     *        hull strength of ship
     * @param police
     *        police disposition
     * @param pirate
     *        pirate disposition
     * @param sizeArg
     *        size of ship
     */
    private Ship(String nameArg, int cargoSize, int weaponSize, int shieldSize, int gadgetSize,
        int crewSize, int maxFuelArg, int fuelCostArg, int priceArg, int bountyArg,
        int hullStrengthArg, int police, int pirate, int sizeArg) {
        //cargo = new Good[cargoSize];
        cargo = new PresizedList<Good>(cargoSize);
        weapons = new PresizedList<Weap>(weaponSize);
        shields = new PresizedList<Shie>(shieldSize);
        gadgets = new PresizedList<AbstractGadget>(gadgetSize);
        crew = new PresizedList<Crew>(crewSize);
        this.name = nameArg;
        this.maxFuel = maxFuelArg;
        this.fuelCost = fuelCostArg;
        this.price = priceArg;
        this.bounty = bountyArg;
        this.hullStrength = hullStrengthArg;
        policeAggression = police;
        pirateAggression = pirate;
        this.size = sizeArg;
        currentFuel = maxFuel;
        isVisible = true;
    }

    /**
     * Returns the number of empty slots for cargo.
     *
     * @return number of empty slots for cargo
     */
    public int cargoRoomLeft() {
        return cargo.maxSize() - cargo.Count;
    }

    /**
     * Returns the list of cargo the Ship contains.
     *
     * @return list of cargo
     */
    public IList<Good> getCargo() {
        return cargo;
    }

    /**
     * used with CargoGadget.
     *
     * @param newCargo
     *        the new backing cargo for the ship
     */
    public void setCargo(PresizedList<Good> newCargo) {
        this.cargo = newCargo;
    }

    /**
     * Used with FuelGadget.
     *
     * @param cost
     *        the new fuel cost of the ship
     */
    public void setFuelCost(int cost) {
        fuelCost = cost;
    }

    /**
     * Used with CloakingGadget.
     *
     * @param canSee
     *        whether or not the ship is visible
     */
    public bool Visible {
        get { return isVisible; }
        set { isVisible = value; }
    }


    /**
     * Adds cargo to the ship.
     *
     * @param item
     *        the item to add
     * @return true if item was added, false otherwise
     * @throws IllegalArgumentException
     *         if item is null
     */
    public bool addCargo(Good item) {
        return cargo.Add(item);
    }

    /**
     * Looks through the cargo to find the given item.
     *
     * @param item
     *        the item to look for. null if item not in cargo
     * @return the matching item if found or null if no items match
     * @throws IllegalArgumentException
     *         if item is null
     */
    public Good removeCargo(Good item) {
        bool wasRemoved = cargo.Remove(item);
        if (wasRemoved) {
            return item;
        } else {
            return null;
        }
    }

    /**
     * Adds a gadget to the ship.
     *
     * @param gadget
     *        the gadget to add
     * @return true iff gadget was added and effect was applied
     */
    public bool addGadget(AbstractGadget gadget) {
        if (gadgets.hasRoom()) {
            gadgets.Add(gadget);
            return gadget.applyEffect();
        }

        return false;
    }

    /**
     * Removed a gadget from the the ship.
     *
     * @param gadget
     *        the gadget to remove
     * @return true iff the gadget and its effect were removed
     */
    public bool removeGadget(AbstractGadget gadget) {
        if (gadgets.Remove(gadget)) {
            return gadget.removeEffect();
        }

        return false;
    }

    /**
     * Adds a crew member to the ship.
     *
     * @param member
     *        the Crew member to add
     * @return true iff the Crew member was added
     */
    public bool addCrew(Crew member) {
        if (crew.hasRoom()) {
            return crew.Add(member);
        }

        return false;
    }

    /**
     * Removes a crew member from the ship.
     *
     * @param member
     *        the Crew member to remove
     * @return true iff the Crew member was removed
     */
    public bool removeCrew(Crew member) {
        return crew.Remove(member);
    }

    /**
     * Adds the weapon to the ship.
     *
     * @param weapon
     *        the weapon to add
     * @return true iff the weapon is removed
     */
    public bool addWeapon(Weap weapon) {
        if (weapons.hasRoom()) {
            weapons.Add(weapon);
            return true;
        }

        return false;
    }

    /**
     * Removes the weapon from the ship.
     *
     * @param weapon
     *        the weapon to remove
     * @return true iff the weapon was removed
     */
    public bool removeWeapon(Weap weapon) {
        return weapons.Remove(weapon);
    }

    /**
     * The shield to add the ship.
     *
     * @param shield
     *        the shield to add
     * @return true iff the shield was added
     */
    public bool addShield(Shie shield) {
        if (shields.hasRoom()) {
            shields.Add(shield);
            return true;
        }

        return false;
    }

    /**
     * Removes the shield from the ship.
     *
     * @param shield
     *        the shield to remove
     * @return true iff the shield was removed
     */
    public bool removeShield(Shie shield) {
        return shields.Remove(shield);
    }

    /**
     * Remove [distance] units of fuel after travelling distance.
     *
     * @param distance
     *        the distance to travel
     */
    public void travel(int distance) {
        currentFuel -= distance;
    }

    /**
     * Returns the current amount of fuel.
     *
     * @return current fuel
     */
    public int getCurrentFuel() {
        return currentFuel;
    }

    /**
     * Adds fuel to the ship.
     *
     * @param amount
     *        the amount of fuel
     */
    public void buyFuel(int amount) {
        currentFuel += amount;
    }

    /**
     * Returns the maximum amount of fuel.
     *
     * @return maxFuel
     */
    public int getMaxFuel() {
        return maxFuel;
    }

    /*
     * Getter methods below
     */

    /**
     * Returns the fuel cost per unit.
     *
     * @return fuel cost per unit
     */
    public int getFuelCost() {
        return fuelCost;
    }

    /**
     * Returns the base price of ship.
     *
     * @return base price
     */
    public int getPrice() {
        return price;
    }

    /**
     * Gets max size of cargo.
     *
     * @return maximum number of elements in the cargo
     */
    public int cargoSize() {
        return cargo.maxSize();
    }

    /**
     * Gets max size of weapons.
     *
     * @return max num of weapons
     */
    public int weaponsSize() {
        return weapons.maxSize();
    }

    /**
     * Gets max size of shields.
     *
     * @return max num of shields.
     */
    public int shieldsSize() {
        return shields.maxSize();
    }

    /**
     * Gets max num of crew.
     *
     * @return max num of crew
     */
    public int crewSize() {
        return crew.maxSize();
    }

    /**
     * Gets max num of gadgets.
     *
     * @return max num of gadgets.
     */
    public int gadgetSize() {
        return gadgets.maxSize();
    }

    /**
     * Returns a list of the ship's weapons.
     *
     * @return a list of weapons.
     */
    public IList<Weap> getWeapons() {
        return weapons;
    }

    /**
     * Returns a list of the ship's shields.
     *
     * @return list of shields.
     */
    public IList<Shie> getShields() {
        return shields;
    }

    /**
     * Returns a list of the ship's gadgets.
     *
     * @return list of gadgets
     */
    public IList<AbstractGadget> getGadgets() {
        return gadgets;
    }

    /**
     * Returns a list of the ship's crew.
     *
     * @return a list of the crew.
     */
    public IList<Crew> getCrew() {
        return crew;
    }

    /**
     * Returns a Map of attribute name to atribute value.
     *
     * @return map of instance variable -> value
     */
    public Dictionary<String, Int32> specs() {
        Dictionary<String, Int32> retval = new Dictionary<String, Int32>
        {
            {"Max Fuel", maxFuel},
            {"Fuel Cost", fuelCost},
            {"Base Price", price},
            {"Bounty", bounty},
            {"Hull Strength", hullStrength},
            {"Police Disposition", policeAggression},
            {"Pirate Aggression", pirateAggression},
            {"Cargo Size", cargoSize()},
            {"Weapons Size", weaponsSize()},
            {"Crew Size", crewSize()},
            {"Gadget Size", gadgetSize()},
            {"Shield Size", shieldsSize()}
        };

        return retval;

    }

    
    public String toString() {
        return name;
    }

}