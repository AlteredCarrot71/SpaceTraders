using System;

/**
 * The interface for events applying the strategy pattern. Each behavior does some different effect
 *
 * @author ngraves3
 *
 */
public interface EventStrategy {

    /**
     * Applies the given action to the player.
     *
     * @param p
     *        the player to affect
     * @return the message associated with the outcome of the event
     */
    String execute(Player p);

}
