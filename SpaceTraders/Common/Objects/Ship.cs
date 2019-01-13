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
        // Name of a ship.
        public String Name { get; set; }

        // ship cargo.
        public List<Good> Cargo { get; set; }

        // cargo max size
        public int MaxCargo { get; set; }
        
        // ship weapons.
        public List<Weapon> Weapons { get; set; }

        // weapons max size
        public int MaxWeapon { get; set; }

        // Ship shields.
        public List<Shield> Shields { get; set; }

        // shields max size
        public int MaxShield { get; set; }

        // Ship gadgets.
        public List<Abstract.Gadget> Gadgets { get; set; }

        // gadgets max size
        public int MaxGadget { get; set; }

        // crew max size
        public int MaxCrew { get; set; }

        // Ship crew.
        public List<Abstract.CrewMember> Crew { get; set; }

        // Maximum fuel this ship can hold.
        public int MaxFuel { get; set; }

        // the current amount of fuel.
        public int CurrentFuel { get; set; }

        // cost per unit of fuel.
        public int FuelCost { get; set; }

        // base price of ship.
        public int Price { get; set; }

        // Bounty on ship.
        public int Bounty { get; set; }

        // hull strength for fights.
        public int HullStrength { get; set; }

        // the current amount of hull strength
        public int CurrentHullStrength { get; set; }

        // Police disposition towards ship.
        public int PoliceAggression { get; set; }

        // Pirate aggression towards ship.
        public int PirateAggression { get; set; }

        // Min TechLevel to buy a ship
        public TechLevel MinTechLevel { get; set; }

        // Description of a ship
        public String Text { get; set; }

        // whether can ship be seen by others during travel.
        public bool IsVisible { get; set; }

        // Ship constructor. Makes new ships through methods.
        public Ship() { }
    }
}
