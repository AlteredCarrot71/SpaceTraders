using System;

// A factory class for creating RandomEvents.
namespace SpaceTraders
{
    public class EventFactory
    {
        // The chance that an actual event is generated and not a NullStrategy event.
        private readonly double EventChance = 0.10;

        // The differnt types of events.
        //TODO: implement opponents (police, pirate)
        private enum EventType
        {
            NULL_EVENT, FUEL_EVENT, MONEY_EVENT, GOODS_EVENT
        }

        // Gets a random EventType that is not NULL_EVENT
        public EventType GetNonNullEvent()
        {
            int index = new Random().Next(Enum.GetValues(typeof(EventType)).Length - 1) + 1;

            return (EventType)index;
        }

        // Creates a truly random RandomEvent.
        public RandomEvent CreateRandomEvent(Player player)
        {
            EventType et = (new Random().NextDouble() <= EventChance)
                            ? GetNonNullEvent() : EventType.NULL_EVENT;

            return CreateEvent(player, et);
        }

        // Creates a RandomEvent based on the input.
        private RandomEvent CreateEvent(Player player, EventType eventType)
        {
            EventStrategy strategy;

            switch (eventType)
            {
                case EventType.NULL_EVENT:
                    strategy = new NullStrategy();
                    break;
                case EventType.FUEL_EVENT:
                    strategy = new FuelStrategy();
                    break;
                case EventType.MONEY_EVENT:
                    strategy = new MoneyStrategy();
                    break;
                case EventType.GOODS_EVENT:
                    strategy = new GoodsStrategy();
                    break;
                default:
                    strategy = new NullStrategy();
                    break;
            }

            return new RandomEvent(player, strategy);
        }
    }
}
