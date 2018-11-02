using System;
using System.Collections.Generic;

// Represents a trade good. All goods have prices and different attributes
namespace SpaceTraders
{
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
