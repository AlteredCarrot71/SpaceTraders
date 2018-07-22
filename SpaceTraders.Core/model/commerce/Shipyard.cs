using System.Runtime.Serialization;
/**
 * Class representing the Shipyard where a player can upgrade and swap ships.
 *
 * @author ngraves3
 *
 */

namespace SpaceTraders
{

    public class Shipyard
    {

        /**
         * Knows about market to get prices for goods.
         */
        private Marketplace marketplace;

        /**
         * Knows about player to get ship and add/remove money.
         */
        private Player player;

        /**
         * Constructor for shipyard.
         *
         * @param marketplaceArg
         *        the market to draw cargo prices from
         * @param playerArg
         *        the player buying the ship
         */
        public Shipyard(Marketplace marketplaceArg, Player playerArg)
        {
            this.marketplace = marketplaceArg;
            this.player = playerArg;
        }

        /**
         * Returns the cost (or income) to buy the ship. If cost is negative, than
         * the player will receive money upon changing the ship. the cost of the
         * ship is decreased for each item in the cargo
         *
         * @param shipToBuy
         *        the ship to buy
         * @return the net cost of the ship to buy
         */
        public int costToBuy(Ship shipToBuy)
        {

            int total = shipToBuy.getPrice();

            foreach (Good cargo in player.Ship.getCargo())
            {
                total -= marketplace.GetPrice(cargo);
            }

            foreach (HasPrice upgrade in player.GetUpgrades())
            {
                total -= upgrade.getPrice();
            }

            total -= player.Ship.getPrice();

            return total;
        }

        /**
         * The player buys a ship. This method removes the ship from the player and
         * assigns the new ship to the player. It also removes or adds the
         * appropriate amount of money from the player
         *
         * @param shipToBuy
         *        the ship the player wants to buy
         */
        public void buyShip(Ship shipToBuy)
        {
            player.ChangeMoney(costToBuy(shipToBuy) * -1);
            player.Ship = shipToBuy;
        }

    }
}
