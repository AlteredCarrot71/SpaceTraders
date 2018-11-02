using System;
// Represents a trade good. All goods have prices and different attributes
using System.Collections.Generic;

namespace SpaceTraders
{
    public static class Goods
    {
        // values for Water good.
        public static readonly Good WATER = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Water/Name"),
            MinTechToProduce = TechLevel.PRE_AG,
            MinTechToUse = TechLevel.PRE_AG,
            MainProducer = TechLevel.MEDIEVAL,
            BasePrice = 30,
            PriceIncreasePerLevel = 3,
            Variance = 4,
            MinSpacePrice = 30,
            MaxSpacePrice = 50
        };

        // Values for Furs good.
        public static readonly Good FURS = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Furs/Name"),
            MinTechToProduce = TechLevel.PRE_AG,
            MinTechToUse = TechLevel.PRE_AG,
            MainProducer = TechLevel.PRE_AG,
            BasePrice = 250,
            PriceIncreasePerLevel = 10,
            Variance = 10,
            MinSpacePrice = 230,
            MaxSpacePrice = 280
        };

        // Values for Food good.
        public static readonly Good FOOD = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Food/Name"),
            MinTechToProduce = TechLevel.AGRICULTURE,
            MinTechToUse = TechLevel.PRE_AG,
            MainProducer = TechLevel.AGRICULTURE,
            BasePrice = 100,
            PriceIncreasePerLevel = 5,
            Variance = 5,
            MinSpacePrice = 90,
            MaxSpacePrice = 260
        };

        // Values for Ore good.
        public static readonly Good ORE = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Ore/Name"),
            MinTechToProduce = TechLevel.MEDIEVAL,
            MinTechToUse = TechLevel.MEDIEVAL,
            MainProducer = TechLevel.RENAISSANCE,
            BasePrice = 250,
            PriceIncreasePerLevel = 20,
            Variance = 10,
            MinSpacePrice = 350,
            MaxSpacePrice = 420
        };

        // Values for Game good.
        public static readonly Good GAMES = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Games/Name"),
            MinTechToProduce = TechLevel.RENAISSANCE,
            MinTechToUse = TechLevel.AGRICULTURE,
            MainProducer = TechLevel.POST_INDUSTRIAL,
            BasePrice = 250,
            PriceIncreasePerLevel = -10,
            Variance = 5,
            MinSpacePrice = 160,
            MaxSpacePrice = 270
        };

        // Values for Firearm good.
        public static readonly Good FIREARMS = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Firearms/Name"),
            MinTechToProduce = TechLevel.RENAISSANCE,
            MinTechToUse = TechLevel.AGRICULTURE,
            MainProducer = TechLevel.INDUSTRIAL,
            BasePrice = 1250,
            PriceIncreasePerLevel = -75,
            Variance = 100,
            MinSpacePrice = 600,
            MaxSpacePrice = 1100
        };

        // Values for Medicine good.
        public static readonly Good MEDICINE = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Medicine/Name"),
            MinTechToProduce = TechLevel.EARLY_INDUSTRIAL,
            MinTechToUse = TechLevel.AGRICULTURE,
            MainProducer = TechLevel.POST_INDUSTRIAL,
            BasePrice = 650,
            PriceIncreasePerLevel = -20,
            Variance = 10,
            MinSpacePrice = 400,
            MaxSpacePrice = 700
        };

        // Values for Machines good.
        public static readonly Good MACHINES = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Machines/Name"),
            MinTechToProduce = TechLevel.EARLY_INDUSTRIAL,
            MinTechToUse = TechLevel.RENAISSANCE,
            MainProducer = TechLevel.INDUSTRIAL,
            BasePrice = 900,
            PriceIncreasePerLevel = -30,
            Variance = 5,
            MinSpacePrice = 600,
            MaxSpacePrice = 800
        };

        // Values for Narcotics good.
        public static readonly Good NARCOTICS = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Narcotics/Name"),
            MinTechToProduce = TechLevel.INDUSTRIAL,
            MinTechToUse = TechLevel.PRE_AG,
            MainProducer = TechLevel.INDUSTRIAL,
            BasePrice = 3500,
            PriceIncreasePerLevel = -125,
            Variance = 150,
            MinSpacePrice = 2000,
            MaxSpacePrice = 3000
        };

        // Values for Robots good.
        public static readonly Good ROBOTS = new Good
        {
            Name = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("Good/Robots/Name"),
            MinTechToProduce = TechLevel.POST_INDUSTRIAL,
            MinTechToUse = TechLevel.EARLY_INDUSTRIAL,
            MainProducer = TechLevel.HI_TECH,
            BasePrice = 5000,
            PriceIncreasePerLevel = -150,
            Variance = 100,
            MinSpacePrice = 3500,
            MaxSpacePrice = 5000
        };

        public static readonly List<Good> Values = new List<Good>() { WATER, FURS, FOOD, ORE, GAMES, FIREARMS, MEDICINE, MACHINES, NARCOTICS, ROBOTS };
    }

    public class Good
    {
        public String Name { get; set; }

        // Min tech to produce on Planet.
        public TechLevel MinTechToProduce { get; set; }
        // Min tech to sell to a planet.
        public TechLevel MinTechToUse { get; set; }
        // Main producer of this good.
        public TechLevel MainProducer { get; set; }
        // Base price of this good.
        public int BasePrice { get; set; }
        // Delta price per level.
        public int PriceIncreasePerLevel { get; set; }
        // Amount of randomness allowed in price.
        public int Variance { get; set; }
        // Min price for trader encounters.
        public int MinSpacePrice { get; set; }
        // Max price for trader encounters.
        public int MaxSpacePrice { get; set; }

        // Constructor for a Goods object.
        public Good() { }

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
