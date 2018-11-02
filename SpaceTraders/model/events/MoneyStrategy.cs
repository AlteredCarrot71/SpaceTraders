using System;

/**
 * Private class to handle money events.
 *
 * @author ngraves3
 *
 */

namespace SpaceTraders
{
    public class MoneyStrategy : EventStrategy
    {
        /**
         * Phrases for gaining money.
         */
        private String[] addPhrases = {
                "Your last lotto ticket was worth {0}! credits",
                "{0} credits fell into your hand!",
                "You found {0} credits in your back pocket!",
                "An old man gave you {0} credits (and a weird wink...)",
                "You helped a little old lady carry her groceries "
                                + "to the car and she gave you {0} credits!"};

        /**
         * Phrases for losing money.
         */
        private String[] minusPhrases = {"You lost {0} credits playing a shell game!",
                "{0} credits fell out of your pocket! Oops!",
                "You were mugged and had {0} credits stolen!",
                "Unexpected taxes in this market cost you {0} credits!",
                "You gave {0} credits to a crying orphan!"};

        public String execute(Player player)
        {
            Random rand = new Random();
            int money = rand.Next((player.Money * 2) + 1);
            money -= player.Money;

            if (money == 0)
            {
                money++;
            }

            player.Money = money; //adding negative money is taking money

            if (money > 0)
            {
                return String.Format(addPhrases[rand.Next(addPhrases.Length)], money);
            }
            else
            {
                return String.Format(minusPhrases[rand.Next(minusPhrases.Length)], -1 * money);
            }
        }
    }
}
