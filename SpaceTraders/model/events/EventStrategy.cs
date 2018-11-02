using System;

namespace SpaceTraders
{
    // The interface for events applying the strategy pattern. Each behavior does some different effect
    public interface IEventStrategy
    {
        // Applies the given action to the player.
        String Execute(Player p);
    }
}
