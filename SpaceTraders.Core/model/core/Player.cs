using System;
using System.Collections.Generic;

/* This class represents the Player and his state.
 *
 * @author ngraves3
 *
 */

public class Player : HasSkills {

    /**
     * Nameof character.
     */
    private String name;

    /**
     * Skills of character.
     */
    private SkillSet skills;

    /**
     * Players money.
     */
    private int money = 0;

    /**
     * Player's ship.
     */
    private Ship ship;

    /**
     * Constrcutor for player.
     *
     * @param nameArg
     *        player name
     * @param pilotSkill
     *        skill at piloting
     * @param fightSkill
     *        skill at fighting
     * @param engSkill
     *        skill at engineering
     * @param tradeSkill
     *        skill at trading
     * @param investSkill
     *        skill at investing
     */
    public Player(String nameArg, int pilotSkill, int fightSkill, int engSkill,
        int tradeSkill, int investSkill) {
        this.name = nameArg;
        skills = new SkillSet(tradeSkill, fightSkill, engSkill,
                                        pilotSkill, investSkill);
        this.ship = Ship.gnat();

    }

    /**
     * Gets the player's money.
     *
     * @return player's money
     */
    public int getMoney() {
        return money;
    }

    /**
     * Adds money to the player's money.
     *
     * @param income
     *        amount of money to add
     */
    public void addMoney(int income) {
        this.money += income;
    }

    /**
     * Removes money from the player's money.
     *
     * @param cost
     *        the amount to remove
     */
    public void subtractMoney(int cost) {
        addMoney(-cost);
    }

    /**
     * Returns ship of the player.
     *
     * @return player's ship
     */
    public Ship getShip() {
        return ship;
    }

    /**
     * Sets the players ship to this new ship.
     *
     * @param otherShip
     *        the player's new ship
     */
    public void changeShip(Ship otherShip) {
        ship = otherShip;
    }

    /**
     * Returns an int of how many cargo spaces are left.
     *
     * @return int number of slots left
     */
    public int cargoRoomLeft() {
        return ship.cargoRoomLeft();
    }

    /**
     * Adds the item to the cargo.
     *
     * @param item
     *        the cargo to add
     */
    public void addCargo(Good item) {
        ship.addCargo(item);
    }

    /**
     * Returns a list of the cargo.
     *
     * @return cargo in list form
     */
    public IList<Good> getCargo() {
        return ship.getCargo();
    }

    /**
     * Returns a list of the current upgrades of the ship.
     *
     * @return list of upgrades
     */
    public IList<HasPrice> getUpgrades() {
        IList<HasPrice> upgrades = new List<HasPrice>();

        foreach (HasPrice weapon in ship.getWeapons()) {
           upgrades.Add(weapon);
        }  
           
        foreach (HasPrice shield in ship.getShields()) {
           upgrades.Add(shield);
        }  
           
        foreach (Crew crew in ship.getCrew()) {
            upgrades.Add(crew);
        }  
           
        foreach (AbstractGadget gadget in ship.getGadgets()) {
            upgrades.Add(gadget);
        }

        return upgrades;
    }

    /**
     * Removes an item from cargo.
     *
     * @param item
     *        the cargo to remove
     * @return the item removed; null if doesnt exist in cargo
     */
    public Good removeCargo(Good item) {
        return ship.removeCargo(item);
    }

    /**
     * Travels the distance. Uses distance units of fuel
     *
     * @param distance distance to travel
     */
    public void travel(int distance) {
        ship.travel(distance);
    }

    /**
     * Gets the base price of the ship. used when exchanging ships.
     *
     * @return the base price of the ship
     */
    public int getShipBasePrice() {
        return ship.getPrice();
    }

    /**
     * Gets maximum amount of fuel for the given Ship.
     *
     * @return maximum amount of fuel in Ship
     */
    public int getMaxFuel() {
        return ship.getMaxFuel();
    }

    /**
     * Get the fuel cost of the Player's ship.
     *
     * @return the cost of 1 unit of fuel
     */
    public int getFuelCost() {
        return ship.getFuelCost();
    }

    /**
     * Gets the current amount of fuel.
     *
     * @return fuel left in Ship
     */
    public int getCurrentFuel() {
        return ship.getCurrentFuel();
    }

    /**
     * Adds fuel to the player's ship and removes the appropriate amount of money from the player.
     */
    public void buyFuel() {
        int quantity = calculateFuelQuantity();
        ship.buyFuel(quantity);
        subtractMoney(quantity * getFuelCost());
    }

    /**
     * Returns the total cost of refueling a ship.
     *
     * @return cost of refueling
     */
    public int getRefuelCost() {
        return calculateFuelQuantity() * getFuelCost();
    }

    /**
     * Calculates the amount of fuel a player can buy based on money and fuel cost.
     *
     * @return quantity of fuel a player can buy
     */
    private int calculateFuelQuantity() {
        int fuelAmount = ship.getMaxFuel() - ship.getCurrentFuel();

        if ((fuelAmount * ship.getFuelCost()) > money) {
            fuelAmount = money / ship.getFuelCost();
        }

        return fuelAmount;
    }

    
    public String toString() {
        String term = "\n";
        String retval = "Name: " + name + term;
        retval += "Piloting skill: " + getPilotSkill() + term;
        retval += "Fighting skill: " + getFightingSkill() + term;
        retval += "Engineering skill: " + getEngineeringSkill() + term;
        retval += "Trading Skill: " + getTradeSkill() + term;
        retval += "Investing Skill: " + getInvestingSkill() + term;
        retval += "Ship: " + ship.toString();
        return retval;
    }

    /**
     * Returns the player's name.
     *
     * @return player name
     */
    public String getName() {
        return name;
    }

    /*
     * The below methods need to account for a Crew members skill too
     */

    
    public int getTradeSkill() {
        int total = skills.Trading;
        foreach (Crew member in ship.getCrew()) {
            total += member.getTradeSkill();
        }
        return total;
    }

    
    public int getEngineeringSkill() {
        int total = skills.Engeneering;
        foreach (Crew member in ship.getCrew()) {
            total += member.getEngineeringSkill();
        }
        return total;
    }

    
    public int getPilotSkill() {
        int total = skills.Piloting;
        foreach (Crew member in ship.getCrew()) {
            total += member.getPilotSkill();
        }
        return total;
    }

    
    public int getFightingSkill() {
        int total = skills.Fighting;
        foreach (Crew member in ship.getCrew()) {
            total += member.getFightingSkill();
        }
        return total;
    }

    
    public int getInvestingSkill() {
        int total = skills.Investing;
        foreach (Crew member in ship.getCrew()) {
            total += member.getInvestingSkill();
        }
        return total;
    }
}
