using System;
// Represents a trade good. All goods have prices and different attributes
using System.Collections.Generic;

namespace SpaceTraders
{
    public class Goods
    {
        // values for Water good.
        public static readonly Good WATER = new Good(TechLevel.PRE_AG, TechLevel.PRE_AG, TechLevel.MEDIEVAL, 30, 3, 4, 30,
            50, "Water");

        // Values for Furs good.
        public static readonly Good FURS = new Good(TechLevel.PRE_AG, TechLevel.PRE_AG, TechLevel.PRE_AG, 250, 10, 10, 230,
            280, "Furs");

        // Values for Food good.
        public static readonly Good FOOD = new Good(TechLevel.AGRICULTURE, TechLevel.PRE_AG, TechLevel.AGRICULTURE, 100, 5,
            5, 90, 260, "Food");

        // Values for Ore good.
        public static readonly Good ORE = new Good(TechLevel.MEDIEVAL, TechLevel.MEDIEVAL, TechLevel.RENAISSANCE, 350, 20,
            10, 350, 420, "Ore");

        // Values for Game good.
        public static readonly Good GAMES = new Good(TechLevel.RENAISSANCE, TechLevel.AGRICULTURE,
            TechLevel.POST_INDUSTRIAL, 250, -10, 5, 160, 270, "Games");

        // Values for Firearm good.
        public static readonly Good FIREARMS = new Good(TechLevel.RENAISSANCE, TechLevel.AGRICULTURE,
            TechLevel.INDUSTRIAL, 1250, -75, 100, 600, 1100, "Firearms");

        // Values for Medicine good.
        public static readonly Good MEDICINE = new Good(TechLevel.EARLY_INDUSTRIAL, TechLevel.AGRICULTURE,
            TechLevel.POST_INDUSTRIAL, 650, -20, 10, 400, 700, "Medicine");

        // Values for Machines good.
        public static readonly Good MACHINES = new Good(TechLevel.EARLY_INDUSTRIAL, TechLevel.RENAISSANCE,
            TechLevel.INDUSTRIAL, 900, -30, 5, 600, 800, "Machines");

        // Values for Narcotics good.
        public static readonly Good NARCOTICS = new Good(TechLevel.INDUSTRIAL, TechLevel.PRE_AG, TechLevel.INDUSTRIAL,
            3500, -125, 150, 2000, 3000, "Narcotics");

        // Values for Robots good.
        public static readonly Good ROBOTS = new Good(TechLevel.POST_INDUSTRIAL, TechLevel.EARLY_INDUSTRIAL,
            TechLevel.HI_TECH, 5000, -150, 100, 3500, 5000, "Robots");

        public static readonly List<Good> Values = new List<Good>() { WATER, FURS, FOOD, ORE, GAMES, FIREARMS, MEDICINE, MACHINES, NARCOTICS, ROBOTS };
    }

    public class Good
    {
        // Min tech to produce on Planet.
        public TechLevel MinTechToProduce { get; private set; }
        // Min tech to sell to a planet.
        public TechLevel MinTechToUse { get; private set; }
        // Main producer of this good.
        private TechLevel MainProducer { get; set; }
        // Base price of this good.
        private int BasePrice { get; set; }
        // Delta price per level.
        private int PriceIncreasePerLevel { get; set; }
        // Amount of randomness allowed in price.
        private int Variance { get; set; }
        // Min price for trader encounters.
        private int MinSpacePrice { get; set; }
        // Max price for trader encounters.
        private int MaxSpacePrice { get; set; }

        public String Name { get; private set; }

        // Constructor for a Goods object.
        public Good(TechLevel minTechProduceLocal, TechLevel minTechToUseLocal,
            TechLevel mainProducerLocal, int basePriceLocal, int priceIncreasePerLevelLocal,
            int varianceLocal, int minSpacePriceLocal, int maxSpacePriceLocal, String aname)
        {

            MinTechToProduce = minTechProduceLocal;
            MinTechToUse = minTechToUseLocal;
            MainProducer = mainProducerLocal;
            BasePrice = basePriceLocal;
            PriceIncreasePerLevel = priceIncreasePerLevelLocal;
            Variance = varianceLocal;
            MinSpacePrice = minSpacePriceLocal;
            MaxSpacePrice = maxSpacePriceLocal;
            Name = aname;
        }

        // Gets the adjusted price of a good.
        public int Price(TechLevel planetTech)
        {
            int randomVariance = new Random().Next(2 * Variance) - Variance;
            return BasePrice
                            + (PriceIncreasePerLevel * ((int)planetTech - (int)MinTechToProduce))
                            + randomVariance;
        }
    }
}
