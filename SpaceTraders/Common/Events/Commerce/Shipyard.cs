// Class representing the Shipyard where a player can upgrade and swap ships.
namespace SpaceTraders
{
    public class Shipyard
    {
        // Knows about market to get prices for goods.
        private Marketplace marketplace;

        // Constructor for shipyard.
        public Shipyard()
        {
            marketplace = Game.Instance.Universe.CurrentPlanet.Marketplace;
        }

        // Returns the cost (or income) to buy the ship. If cost is negative, than
        // the player will receive money upon changing the ship. the cost of the
        // ship is decreased for each item in the cargo
        public int CostToBuy(Ship shipToBuy)
        {
            int total = shipToBuy.Price;

            foreach (Good cargo in Game.Instance.Player.Ship.Cargo)
            {
                total -= marketplace.GetPrice(cargo);
            }

            //TODO: implement gadgets
            total -= Game.Instance.Player.Ship.Price;

            return total;
        }

        // The player buys a ship. This method removes the ship from the player and
        // assigns the new ship to the player. It also removes or adds the
        // appropriate amount of money from the player
        public void BuyShip(Ship shipToBuy)
        {
            Game.Instance.Player.Money -= CostToBuy(shipToBuy);
            Game.Instance.Player.Ship = shipToBuy;
        }

        //TODO: implement gadgets
    }
}
