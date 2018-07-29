using System;
using System.Collections.Generic;

namespace SpaceTraders
{
    // This class represents a Ship object. A ship contains cargo, weapons, shields,
    // gadgets, and crew. It also has fuel, a purchasing price, and NPC disposition
    // modifiers. Converted from enum to class so object would be serialized
    // correctly
    public class Ship
    {
        // makes a flea.
        public static Ship Flea = new Ship( "Flea", 10, 0, 0, 0, 1, 500, 1, 2000, 5, 25, -1, -1, 
                                            TechLevel.EARLY_INDUSTRIAL,
                                            Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetStringForUri(new System.Uri("ms-appx:///Strings/en-US/Resources/Flea.Description"))
                                          );
        // Makes a gnat.
        public static Ship Gnat = new Ship( "Gnat", 15, 1, 0, 1, 1, 140, 2, 10000, 50, 100, 0, 0, 
                                            TechLevel.INDUSTRIAL,
                                            Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Gnat/Description")
                                          );
        // Makes a firefly.
        public static Ship Firefly = new Ship( "Firefly", 20, 1, 1, 1, 1, 170, 3, 25000, 75, 100, 0, 0, 
                                               TechLevel.INDUSTRIAL,
                                               Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Firefly/Description")
                                             );
        // makes a mosquito.
        public static Ship Mosquito = new Ship( "Mosquito", 15, 2, 1, 1, 1, 130, 5, 30000, 100, 100, 0, 1, 
                                                TechLevel.POST_INDUSTRIAL,
                                                Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Mosquito/Description")
                                              );
        // Makes a bumblebee.
        public static Ship Bumblebee = new Ship( "Bumblebee", 25, 1, 2, 2, 2, 150, 7, 60000, 125, 100, 0, 1, 
                                                 TechLevel.HI_TECH,
                                                 Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Bumblebee/Description")
                                               );

        public static readonly List<Ship> Values = new List<Ship> { Flea, Gnat, Firefly, Mosquito, Bumblebee };

        // ship cargo.
        public List<Good> Cargo { get; set; }

        // ship weapons.
        private PresizedList<Weap> weapons;

        // Ship shields.
        private PresizedList<Shie> shields;

        // Ship gadgets.
        private PresizedList<AbstractGadget> gadgets;

        // Ship crew.
        private PresizedList<Crew> crew;

        // Maximum fuel this ship can hold.
        public int MaxFuel { get; private set; }

        // the current amount of fuel.
        public int CurrentFuel { get; private set; }

        // whether can ship be seen by others during travel.
        public bool IsVisible { get; set; }

        // Name and description of ship.
        public String Name { get; private set; }
        public String Text { get; private set; }

        // Min tech level for ship to be sold in shipyard.
        //private TechLevel minTechLevel;

        // cost per unit of fuel.
        public int FuelCost { get; set; }

        // base price of ship.
        public int Price { get; private set; }

        // Bounty on ship.
        private int bounty;

        // hull strength for fights.
        private int hullStrength;

        // Police disposition towards ship.
        private int policeAggression;

        // Pirate aggression towards ship.
        private int pirateAggression;

        // Min TechLevel to buy a ship
        public TechLevel MinTechLevel { get; private set; }

        // Private ship constructor. Makes new ships through methods.
        private Ship(String nameArg, int cargoSize, int weaponSize, int shieldSize, int gadgetSize,
            int crewSize, int maxFuelArg, int fuelCostArg, int priceArg, int bountyArg,
            int hullStrengthArg, int police, int pirate, TechLevel minTechLevelArg, String text)
        {
            //cargo = new Good[cargoSize];
            Cargo = new List<Good>(cargoSize);
            weapons = new PresizedList<Weap>(weaponSize);
            shields = new PresizedList<Shie>(shieldSize);
            gadgets = new PresizedList<AbstractGadget>(gadgetSize);
            crew = new PresizedList<Crew>(crewSize);
            this.Name = nameArg;
            this.MaxFuel = maxFuelArg;
            this.FuelCost = fuelCostArg;
            this.Price = priceArg;
            this.bounty = bountyArg;
            this.hullStrength = hullStrengthArg;
            this.policeAggression = police;
            this.pirateAggression = pirate;
            this.CurrentFuel = MaxFuel;
            this.IsVisible = true;
            this.MinTechLevel = minTechLevelArg;
            this.Text = text;
        }

        // Returns the number of empty slots for cargo.
        public int cargoRoomLeft()
        {
            return Cargo.Capacity - Cargo.Count;
        }

        // Returns the list of cargo the Ship contains.
        public IList<Good> getCargo()
        {
            return Cargo;
        }

        // used with CargoGadget.
        public void setCargo(PresizedList<Good> newCargo)
        {
            this.Cargo = newCargo;
        }

        // Adds cargo to the ship.
        public bool addCargo(Good item)
        {
            Cargo.Add(item);
            return true;
        }

        // Looks through the cargo to find the given item.
        public bool removeCargo(Good item)
        {
            Cargo.Remove(item);
            return true;
        }

        // Adds a gadget to the ship.
        public bool addGadget(AbstractGadget gadget)
        {
            if (gadgets.hasRoom())
            {
                gadgets.Add(gadget);
                return gadget.applyEffect();
            }

            return false;
        }

        // Removed a gadget from the the ship.
        public bool removeGadget(AbstractGadget gadget)
        {
            if (gadgets.Remove(gadget))
            {
                return gadget.removeEffect();
            }

            return false;
        }

        // Adds a crew member to the ship.
        public bool addCrew(Crew member)
        {
            if (crew.hasRoom())
            {
                return crew.Add(member);
            }

            return false;
        }

        // Removes a crew member from the ship.
        public bool removeCrew(Crew member)
        {
            return crew.Remove(member);
        }

        // Adds the weapon to the ship.
        public bool addWeapon(Weap weapon)
        {
            if (weapons.hasRoom())
            {
                weapons.Add(weapon);
                return true;
            }

            return false;
        }

        // Removes the weapon from the ship.
        public bool removeWeapon(Weap weapon)
        {
            return weapons.Remove(weapon);
        }

        // The shield to add the ship.
        public bool addShield(Shie shield)
        {
            if (shields.hasRoom())
            {
                shields.Add(shield);
                return true;
            }

            return false;
        }

        // Removes the shield from the ship.
        public bool removeShield(Shie shield)
        {
            return shields.Remove(shield);
        }

        // Remove [distance] units of fuel after travelling distance.
        public void travel(int distance)
        {
            CurrentFuel -= distance;
        }

        // Adds fuel to the ship.
        public void buyFuel(int amount)
        {
            CurrentFuel += amount;
        }

        // Gets max size of cargo.
        public int cargoSize()
        {
            return Cargo.Capacity;
        }

        // Gets max size of weapons.
        public int weaponsSize()
        {
            return weapons.maxSize();
        }

        // Gets max size of shields.
        public int shieldsSize()
        {
            return shields.maxSize();
        }

        // Gets max num of crew.
        public int crewSize()
        {
            return crew.maxSize();
        }

        // Gets max num of gadgets.
        public int gadgetSize()
        {
            return gadgets.maxSize();
        }

        // Returns a list of the ship's weapons.
        public IList<Weap> getWeapons()
        {
            return weapons;
        }

        // Returns a list of the ship's shields.
        public IList<Shie> getShields()
        {
            return shields;
        }

        // Returns a list of the ship's gadgets.
        public IList<AbstractGadget> getGadgets()
        {
            return gadgets;
        }

        // Returns a list of the ship's crew.
        public IList<Crew> getCrew()
        {
            return crew;
        }

        // Returns a Map of attribute name to atribute value.
        public Dictionary<String, Int32> specs()
        {
            Dictionary<String, Int32> retval = new Dictionary<String, Int32>
            {
                {"Max Fuel", MaxFuel},
                {"Fuel Cost", FuelCost},
                {"Base Price", Price},
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
    }
}
