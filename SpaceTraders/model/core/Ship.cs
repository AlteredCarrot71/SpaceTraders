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
        public static Ship Flea = new Ship 
        {
            Name = "Flea",
            Cargo = new List<Good>(10),
            Weapons = new List<Weapon>(0),
            Shields = new List<Shield>(0),
            Gadgets = new List<AbstractGadget>(0),
            Crew = new List<Crew>(1),
            MaxFuel = 500,
            FuelCost = 1,
            Price = 2000,
            Bounty = 5,
            HullStrength = 25,
            PoliceAggression = -1,
            PirateAggression = -1,
            MinTechLevel = TechLevel.EARLY_INDUSTRIAL,
            Text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Ship/Flea/Description")
        };

        // Makes a gnat.
        public static Ship Gnat = new Ship
        {
            Name = "Gnat",
            Cargo = new List<Good>(15),
            Weapons = new List<Weapon>(1),
            Shields = new List<Shield>(0),
            Gadgets = new List<AbstractGadget>(1),
            Crew = new List<Crew>(1),
            MaxFuel = 140,
            FuelCost = 2,
            Price = 10000,
            Bounty = 50,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 0,
            MinTechLevel = TechLevel.INDUSTRIAL,
            Text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Ship/Gnat/Description")
        };

        // Makes a firefly.
        public static Ship Firefly = new Ship
        {
            Name = "Firefly",
            Cargo = new List<Good>(20),
            Weapons = new List<Weapon>(1),
            Shields = new List<Shield>(1),
            Gadgets = new List<AbstractGadget>(1),
            Crew = new List<Crew>(1),
            MaxFuel = 170,
            FuelCost = 3,
            Price = 25000,
            Bounty = 75,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 0,
            MinTechLevel = TechLevel.INDUSTRIAL,
            Text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Ship/Firefly/Description")
        };

        // makes a mosquito.
        public static Ship Mosquito = new Ship
        {
            Name = "Mosquito",
            Cargo = new List<Good>(15),
            Weapons = new List<Weapon>(2),
            Shields = new List<Shield>(1),
            Gadgets = new List<AbstractGadget>(1),
            Crew = new List<Crew>(1),
            MaxFuel = 130,
            FuelCost = 5,
            Price = 30000,
            Bounty = 100,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 1,
            MinTechLevel = TechLevel.POST_INDUSTRIAL,
            Text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Ship/Mosquito/Description")
        };

        // Makes a bumblebee.
        public static Ship Bumblebee = new Ship
        {
            Name = "Bumblebee",
            Cargo = new List<Good>(25),
            Weapons = new List<Weapon>(1),
            Shields = new List<Shield>(2),
            Gadgets = new List<AbstractGadget>(2),
            Crew = new List<Crew>(2),
            MaxFuel = 150,
            FuelCost = 7,
            Price = 60000,
            Bounty = 125,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 1,
            MinTechLevel = TechLevel.HI_TECH,
            Text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Ship/Bumblebee/Description")
        };

        public static readonly List<Ship> Values = new List<Ship> { Flea, Gnat, Firefly, Mosquito, Bumblebee };

        // ship cargo.
        public List<Good> Cargo { get; set; }

        // ship weapons.
        public List<Weapon> Weapons { get; set; }

        // Ship shields.
        public List<Shield> Shields { get; set; }

        // Ship gadgets.
        public List<AbstractGadget> Gadgets { get; set; }

        // Ship crew.
        public List<Crew> Crew { get; set; }

        // Maximum fuel this ship can hold.
        public int MaxFuel { get; private set; }  

        // the current amount of fuel.
        public int CurrentFuel { get; set; }

        // whether can ship be seen by others during travel.
        public bool IsVisible { get; set; }

        // Name and description of ship.
        public String Name { get; private set; }
        public String Text { get; private set; }

        // cost per unit of fuel.
        public int FuelCost { get; set; }

        // base price of ship.
        public int Price { get; private set; }

        // Bounty on ship.
        public int Bounty { get; private set; }

        // hull strength for fights.
        public int HullStrength { get; private set; }

        // Police disposition towards ship.
        public int PoliceAggression { get; private set; }

        // Pirate aggression towards ship.
        public int PirateAggression { get; private set; }

        // Min TechLevel to buy a ship
        public TechLevel MinTechLevel { get; private set; }

        // Private ship constructor. Makes new ships through methods.
        public Ship() { }

        // Returns the number of empty slots for cargo.
        public int CargoRoomLeft()
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
            Cargo = newCargo;
        }

        // Adds cargo to the ship.
        public bool addCargo(Good item)
        {
            if (Cargo.Count < Cargo.Capacity)
            {
                Cargo.Add(item);
                return true;
            }

            return false;
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
            if (Gadgets.Count < Gadgets.Capacity)
            {
                Gadgets.Add(gadget);
                return gadget.applyEffect();
            }

            return false;
        }

        // Removed a gadget from the the ship.
        public bool removeGadget(AbstractGadget gadget)
        {
            if (Gadgets.Remove(gadget))
            {
                return gadget.removeEffect();
            }

            return false;
        }

        // Adds a crew member to the ship.
        public bool addCrew(Crew member)
        {
            if (Crew.Count < Crew.Capacity)
            {
                Crew.Add(member);
                return true;
            }

            return false;
        }

        // Removes a crew member from the ship.
        public bool removeCrew(Crew member)
        {
            return Crew.Remove(member);
        }

        // Adds the weapon to the ship.
        public bool addWeapon(Weapon weapon)
        {
            if (Weapons.Count < Weapons.Capacity)
            {
                Weapons.Add(weapon);
                return true;
            }

            return false;
        }

        // Removes the weapon from the ship.
        public bool removeWeapon(Weapon weapon)
        {
            return Weapons.Remove(weapon);
        }

        // The shield to add the ship.
        public bool addShield(Shield shield)
        {
            if (Shields.Count < Shields.Capacity)
            {
                Shields.Add(shield);
                return true;
            }

            return false;
        }

        // Removes the shield from the ship.
        public bool removeShield(Shield shield)
        {
            return Shields.Remove(shield);
        }

        // Gets max size of cargo.
        public int cargoSize()
        {
            return Cargo.Capacity;
        }

        // Gets max size of weapons.
        public int weaponsSize()
        {
            return Weapons.Capacity;
        }

        // Gets max size of shields.
        public int shieldsSize()
        {
            return Shields.Capacity;
        }

        // Gets max num of crew.
        public int crewSize()
        {
            return Crew.Capacity;
        }

        // Gets max num of gadgets.
        public int gadgetSize()
        {
            return Gadgets.Capacity;
        }

        // Returns a list of the ship's weapons.
        public IList<Weapon> getWeapons()
        {
            return Weapons;
        }

        // Returns a list of the ship's shields.
        public IList<Shield> getShields()
        {
            return Shields;
        }

        // Returns a list of the ship's gadgets.
        public IList<AbstractGadget> getGadgets()
        {
            return Gadgets;
        }

        // Returns a list of the ship's crew.
        public IList<Crew> getCrew()
        {
            return Crew;
         }

        // Returns a Map of attribute name to atribute value.
        public Dictionary<String, Int32> specs()
        {
            Dictionary<String, Int32> retval = new Dictionary<String, Int32>
            {
                {"Max Fuel", MaxFuel},
                {"Fuel Cost", FuelCost},
                {"Base Price", Price},
                {"Bounty", Bounty},
                {"Hull Strength", HullStrength},
                {"Police Disposition", PoliceAggression},
                {"Pirate Aggression", PirateAggression},
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
