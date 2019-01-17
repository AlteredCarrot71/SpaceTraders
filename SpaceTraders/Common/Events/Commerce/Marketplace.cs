using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceTraders
{
    // Class to act as a service provider between Planet and Player for trading items.
    public class Marketplace
    {
        // Planet tech affects the price of a good in the market.
        private TechLevel planetTech;

        // Set of map of goods this planet can sell inherently (i.e. produce).
        private Dictionary<Good, Int32> productionPrices;

        // Map of goods this planet can buy. Min tech to produce is always >= min tech to use.
        private Dictionary<Good, Int32> purchasePrices;

        // A list of goods the market has for sale.
        public List<Good> Supply { get; private set; }

        // The player buying.
        private Player player;

        // Price modifer based on player's trade skill.
        private int TradeSkillModifier { get; set; }

        // Instantiates a marketplace with the given planet's tech level.
        public Marketplace()
        {
            this.planetTech = Game.Instance.Universe.CurrentPlanet.Techlevel;
            this.player = Game.Instance.Player;
            productionPrices = new Dictionary<Good, Int32>();
            purchasePrices = new Dictionary<Good, Int32>();
            //TODO: implement crew skills
            TradeSkillModifier = new Random().Next((2 * player.TradeSkill) + 1);

            // Initialize goods the planet can produce
            foreach (Good item in Goods.Values)
            {
                // Check if planetTech is higher than minTech for the good
                if (planetTech.CompareTo(item.MinTechToProduce) >= 0)
                {
                    productionPrices.Add(item, AdjustPriceOnSkills(item));
                }
            }

            // Initialize goods the planet can buy. Copy over production goods and
            // add any other goods it can sell.
            foreach (KeyValuePair<Good, int> pair in productionPrices)
            {
                purchasePrices.Add(pair.Key, pair.Value);
            }

            foreach (Good item in Goods.Values)
            {
                if (!productionPrices.ContainsKey(item)
                    && planetTech.CompareTo(item.MinTechToUse) >= 0)
                {
                    purchasePrices.Add(item, AdjustPriceOnSkills(item));
                }
            }

            Random rand = new Random();
            int quantity = rand.Next(9) + 10;

            Supply = new List<Good>(quantity);

            Good[] usableGoods = productionPrices.Keys.ToArray();

            while (Supply.Count < quantity)
            {
                Supply.Add(usableGoods[rand.Next(productionPrices.Count)]);
            }
        }

        // Returns the price of a good based on a player's trade skill.
        private int AdjustPriceOnSkills(Good good)
        {
            return Math.Max(good.Price(planetTech) - TradeSkillModifier, 1);
        }

        // Player buys {quantity} amount of goods from the planet. If the player
        // can't buy that many, don't let him/her.
        public bool PlayerBuys(Good item)
        {
            try
            {
                Supply.Remove(item);
                player.Ship.Cargo.Add(item);
                player.Money -= purchasePrices[item];
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        // Player sells goods to the market.
        public bool PlayerSells(Good item)
        {
            if ( item.MinTechToUse <= planetTech )
            {
                player.Ship.Cargo.Remove(item);
                Supply.Add(item);
                player.Money += purchasePrices[item];
                return true;
            }
            else
            {
                return false;
            }
        }

        // Gets the price for a specific type of Goods.
        public Int32 GetPrice(Good item)
        {
            return purchasePrices.ContainsKey(item) ? purchasePrices[item] : Int32.MaxValue;
        }
    }
}
