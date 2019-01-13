using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

namespace SpaceTraders
{
    public static class Ships
    {
        // makes a flea.
        public static readonly Ship Flea = new Ship
        {
            Name = "Flea",
            Cargo = new List<Good>(10),
            MaxCargo = 10,
            Weapons = new List<Weapon>(0),
            MaxWeapon = 0,
            Shields = new List<Shield>(0),
            MaxShield = 0,
            Gadgets = new List<Abstract.Gadget>(0),
            MaxGadget = 0,
            Crew = new List<Abstract.CrewMember>(1),
            MaxCrew = 1,
            MaxFuel = 500,
            FuelCost = 1,
            Price = 2000,
            Bounty = 5,
            HullStrength = 25,
            PoliceAggression = -1,
            PirateAggression = -1,
            MinTechLevel = TechLevel.EARLY_INDUSTRIAL,
            Text = ResourceLoader.GetForViewIndependentUse().GetString("Ship/Flea/Description")
        };

        // Makes a gnat.
        public static readonly Ship Gnat = new Ship
        {
            Name = "Gnat",
            Cargo = new List<Good>(15),
            MaxCargo = 15,
            Weapons = new List<Weapon>(1),
            MaxWeapon = 1,
            Shields = new List<Shield>(0),
            MaxShield = 0,
            Gadgets = new List<Abstract.Gadget>(1),
            MaxGadget = 1,
            Crew = new List<Abstract.CrewMember>(1),
            MaxCrew = 1,
            MaxFuel = 140,
            FuelCost = 2,
            Price = 10000,
            Bounty = 50,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 0,
            MinTechLevel = TechLevel.INDUSTRIAL,
            Text = ResourceLoader.GetForViewIndependentUse().GetString("Ship/Gnat/Description")
        };

        // Makes a firefly.
        public static readonly Ship Firefly = new Ship
        {
            Name = "Firefly",
            Cargo = new List<Good>(20),
            MaxCargo = 20,
            Weapons = new List<Weapon>(1),
            MaxWeapon = 1,
            Shields = new List<Shield>(1),
            MaxShield = 1,
            Gadgets = new List<Abstract.Gadget>(1),
            MaxGadget = 1,
            Crew = new List<Abstract.CrewMember>(1),
            MaxCrew = 1,
            MaxFuel = 170,
            FuelCost = 3,
            Price = 25000,
            Bounty = 75,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 0,
            MinTechLevel = TechLevel.INDUSTRIAL,
            Text = ResourceLoader.GetForViewIndependentUse().GetString("Ship/Firefly/Description")
        };

        // makes a mosquito.
        public static readonly Ship Mosquito = new Ship
        {
            Name = "Mosquito",
            Cargo = new List<Good>(15),
            MaxCargo = 15,
            Weapons = new List<Weapon>(2),
            MaxWeapon = 2,
            Shields = new List<Shield>(1),
            MaxShield = 1,
            Gadgets = new List<Abstract.Gadget>(1),
            MaxGadget = 1,
            Crew = new List<Abstract.CrewMember>(1),
            MaxCrew = 1,
            MaxFuel = 130,
            FuelCost = 5,
            Price = 30000,
            Bounty = 100,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 1,
            MinTechLevel = TechLevel.POST_INDUSTRIAL,
            Text = ResourceLoader.GetForViewIndependentUse().GetString("Ship/Mosquito/Description")
        };

        // Makes a bumblebee.
        public static readonly Ship Bumblebee = new Ship
        {
            Name = "Bumblebee",
            Cargo = new List<Good>(25),
            MaxCargo = 25,
            Weapons = new List<Weapon>(1),
            MaxWeapon = 1,
            Shields = new List<Shield>(2),
            MaxShield = 2,
            Gadgets = new List<Abstract.Gadget>(2),
            MaxGadget = 2,
            Crew = new List<Abstract.CrewMember>(2),
            MaxCrew = 2,
            MaxFuel = 150,
            FuelCost = 7,
            Price = 60000,
            Bounty = 125,
            HullStrength = 100,
            PoliceAggression = 0,
            PirateAggression = 1,
            MinTechLevel = TechLevel.HI_TECH,
            Text = ResourceLoader.GetForViewIndependentUse().GetString("Ship/Bumblebee/Description")
        };

        public static readonly List<Ship> Values = new List<Ship> { Flea, Gnat, Firefly, Mosquito, Bumblebee };
    }
}
