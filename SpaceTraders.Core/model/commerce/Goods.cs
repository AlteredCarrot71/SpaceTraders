using System;
/**
 * Represents a trade good. All goods have prices and different attributes
 *
 * @author ngraves3
 *
 */
using System.Collections.Generic;
using System.Runtime.Serialization;

public static class Goods
{

    /**
     * values for Water good.
     */

    public static readonly Good WATER = new Good(TechLevel.PRE_AG, TechLevel.PRE_AG, TechLevel.MEDIEVAL, 30, 3, 4, 30,
        50, "Water");

    /**
     * Values for Furs good.
     */

    public static readonly Good FURS = new Good(TechLevel.PRE_AG, TechLevel.PRE_AG, TechLevel.PRE_AG, 250, 10, 10, 230,
        280, "Furs");

    /**
     * Values for Food good.
     */

    public static readonly Good FOOD = new Good(TechLevel.AGRICULTURE, TechLevel.PRE_AG, TechLevel.AGRICULTURE, 100, 5,
        5, 90, 260, "Food");

    /**
     * Values for Ore good.
     */

    public static readonly Good ORE = new Good(TechLevel.MEDIEVAL, TechLevel.MEDIEVAL, TechLevel.RENAISSANCE, 350, 20,
        10, 350, 420, "Ore");

    /**
     * Values for Game good.
     */

    public static readonly Good GAMES = new Good(TechLevel.RENAISSANCE, TechLevel.AGRICULTURE,
        TechLevel.POST_INDUSTRIAL, 250, -10, 5, 160, 270, "Games");

    /**
     * Values for Firearm good.
     */

    public static readonly Good FIREARMS = new Good(TechLevel.RENAISSANCE , TechLevel.AGRICULTURE ,
        TechLevel.INDUSTRIAL , 1250, -75, 100, 600, 1100, "Firearms");

    /**
     * Values for Medicine good.
     */

    public static readonly Good MEDICINE = new Good(TechLevel.EARLY_INDUSTRIAL, TechLevel.AGRICULTURE,
        TechLevel.POST_INDUSTRIAL, 650, -20, 10, 400, 700, "Medicine");

    /**
     * Values for Machines good.
     */

    public static readonly Good MACHINES = new Good(TechLevel.EARLY_INDUSTRIAL, TechLevel.RENAISSANCE,
        TechLevel.INDUSTRIAL, 900, -30, 5, 600, 800, "Machines");

    /**
     * Values for Narcotics good.
     */

    public static readonly Good NARCOTICS = new Good(TechLevel.INDUSTRIAL , TechLevel.PRE_AG , TechLevel.INDUSTRIAL ,
        3500, -125, 150, 2000, 3000, "Narcotics");

    /**
     * Values for Robots good.
     */

    public static readonly Good ROBOTS = new Good(TechLevel.POST_INDUSTRIAL , TechLevel.EARLY_INDUSTRIAL ,
        TechLevel.HI_TECH , 5000, -150, 100, 3500, 5000, "Robots");

    public static readonly List<Good> Values = new List<Good>() {WATER, FURS, FOOD, ORE, GAMES, FIREARMS, MEDICINE, MACHINES, NARCOTICS, ROBOTS}; 
}
    

public class Good
{

/**
     * Min tech to produce on Planet.
     */
    private TechLevel minTechProduce;
    /**
     * Min tech to sell to a planet.
     */
    private TechLevel minTechToUse;
    /**
     * Main producer of this good.
     */
    private TechLevel mainProducer;
    /**
     * Base price of this good.
     */
    private int basePrice;
    /**
     * Delta price per level.
     */
    private int priceIncreasePerLevel;
    /**
     * Amount of randomness allowed in price.
     */
    private int variance;
    /**
     * Min price for trader encounters.
     */
    private int minSpacePrice;
    /**
     * Max price for trader encounters.
     */
    private int maxSpacePrice;

    private String name;

    /**
     * Constructor for a Goods object.
     *
     * @param minTechProduceLocal
     *        the lowest tech on a planet to sell.
     * @param minTechToUseLocal
     *        the lowest tech to sell to a planet.
     * @param mainProducerLocal
     *        the tech level of main producer of good.
     * @param basePriceLocal
     *        the base price before modifiers.
     * @param priceIncreasePerLevelLocal
     *        the increase for each level beyond min.
     * @param varianceLocal
     *        the amount of randomness in prices
     * @param minSpacePriceLocal
     *        the min price for trader encounters
     * @param maxSpacePriceLocal
     *        the max price for trader encounters
     */
    public Good(TechLevel minTechProduceLocal, TechLevel minTechToUseLocal,
        TechLevel mainProducerLocal, int basePriceLocal, int priceIncreasePerLevelLocal,
        int varianceLocal, int minSpacePriceLocal, int maxSpacePriceLocal , String aname) {

        minTechProduce = minTechProduceLocal;
        minTechToUse = minTechToUseLocal;
        mainProducer = mainProducerLocal;
        basePrice = basePriceLocal;
        priceIncreasePerLevel = priceIncreasePerLevelLocal;
        variance = varianceLocal;
        minSpacePrice = minSpacePriceLocal;
        maxSpacePrice = maxSpacePriceLocal;
        name = aname;
        }

    /**
     * Gets the adjusted price of a good.
     *
     * @param planetTech
     *        the tech level of the planet
     * @return the adjusted price of the good
     */
    public int price(TechLevel planetTech) {
        int randomVariance = new Random().Next(2 * variance) - variance;
        return basePrice
                        + (priceIncreasePerLevel * ((int) planetTech - (int) minTechProduce))
                        + randomVariance;
    }

    /**
     * Returns lowest tech level for a planet to buy this goods.
     *
     * @return the above
     */
    public TechLevel MinTechToUse {
        get { return minTechToUse; }
    }

    /**
     * Returns lowest tech needed to inherently sell the good.
     *
     * @return lowest tech level
     */
    public TechLevel minTechToProduce() {
        return minTechProduce;
    }

    public String toString()
    {
        return name;
    }

}
