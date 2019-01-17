using System;

namespace SpaceTraders
{
    // This class represents a Ship object. A ship contains cargo, weapons, shields,
    // gadgets, and crew. It also has fuel, a purchasing price, and NPC disposition
    // modifiers. Converted from enum to class so object would be serialized
    // correctly
    public class Ship : Abstract.Item
    {
        // ship cargo.
        public PresizedList<Good> Cargo { get; set; }

        // ship weapons.
        public PresizedList<Weapon> Weapons { get; set; }

        // Ship shields.
        public PresizedList<Shield> Shields { get; set; }

        // Ship gadgets.
        public PresizedList<Abstract.Item> Gadgets { get; set; }

        // Ship crew.
        public PresizedList<Abstract.CrewMember> Crew { get; set; }

        // Maximum fuel this ship can hold.
        public int MaxFuel { get; set; }

        // the current amount of fuel.
        public int CurrentFuel { get; set; }

        // cost per unit of fuel.
        public int FuelCost { get; set; }

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
