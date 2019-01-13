using System;

// A class representing random events. These are things such as losing fuel, gaining or losing an
// item, or gaining or losing money
namespace SpaceTraders
{
    public class RandomEvent
    {
        // The Player whom the event will affect.
        private readonly Player player;

        // The specific effect the event will have.
        private IEventStrategy effect;

        // The chance that an actual event is generated and not a NullStrategy event.
        private readonly double EventChance = 0.10;

        // The differnt types of events.
        //TODO: implement opponents (police, pirate)
        private enum EventType
        {
            NULL_EVENT, FUEL_EVENT, MONEY_EVENT, GOODS_EVENT
        }

        // Gets a random EventType that is not NULL_EVENT
        private static EventType GetNonNullEvent()
        {
            int index = new Random().Next(Enum.GetValues(typeof(EventType)).Length - 1) + 1;

            return (EventType)index;
        }

        /**
         * Constructor for the random events.
         *
         * @param playerArg
         *        the player to affect
         * @param strat
         *        the strategy used by this random event
         */
        public RandomEvent(Player playerArg)
        {
            this.player = playerArg;

            EventType et = (new Random().NextDouble() <= EventChance)
                ? GetNonNullEvent() : EventType.NULL_EVENT;

            switch (et) 
            {
                case EventType.NULL_EVENT:
                    this.effect = new NullStrategy();
                    break;
                case EventType.FUEL_EVENT:
                    this.effect = new FuelStrategy();
                    break;
                case EventType.MONEY_EVENT:
                    this.effect = new MoneyStrategy();
                    break;
                case EventType.GOODS_EVENT:
                    this.effect = new GoodsStrategy();
                    break;
                default:
                    this.effect = new NullStrategy();
                    break;
            }
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
            return effect.Execute(player);
        }
    }
}
