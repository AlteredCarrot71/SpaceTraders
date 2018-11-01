using System;


namespace SpaceTraders
{
    /**
     * Strategy for handling fuel events.
     *
     * @author ngraves3
     *
     */
    public class FuelStrategy : EventStrategy
    {

        /**
         * Phrases for losing fuel.
         */
        private String[] losePhrases = {"{0} units of your fuel leaked out!",
                "A thief stole {0} units of fuel!"}; //i'm all out of ideas for phrases now


        public String execute(Player player)
        {

            Random rand = new Random();

            int fuelLeakage = rand.Next(player.Ship.CurrentFuel + 1);
            if (fuelLeakage == 0)
            {
                fuelLeakage++; // 1 to player.getCurrentFuel()
            }
            if (player.Ship.CurrentFuel <= 0) return "You left your fuel tank open, but you have no fuel to leak!";
            player.Ship.CurrentFuel -= fuelLeakage;
            int msg = rand.Next(losePhrases.Length);
            return String.Format(losePhrases[msg], fuelLeakage);
        }
    }
}
