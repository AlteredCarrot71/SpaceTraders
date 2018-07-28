
/**
 * A class representing random events. These are things such as losing fuel, gaining or losing an
 * item, or gaining or losing money
 *
 * @author ngraves3
 *
 */

using System;

namespace SpaceTraders
{
    public class RandomEvent
    {

        /**
         * The Player whom the event will affect.
         */
        private Player player;

        /**
         * The specific effect the event will have.
         */
        private EventStrategy effect;

        /**
         * Constructor for the random events.
         *
         * @param playerArg
         *        the player to affect
         * @param strat
         *        the strategy used by this random event
         */
        public RandomEvent(Player playerArg, EventStrategy strat)
        {
            this.player = playerArg;
            this.effect = strat;
        }

        /**
         * this method makes a random event happen in the game universe. It will randomly choose one
         * type of random event and execute it. It has a 10% chance of executing an event (I.e. the
         * strategy for this event is not NullStrategy)
         *
         * @return the message from the event
         */
        public String Event()
        {

            return effect.execute(player);
        }

    }
}
