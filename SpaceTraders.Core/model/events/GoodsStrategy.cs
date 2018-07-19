

/**
 * Private class to handle events involving cargo.
 *
 * @author ngraves3
 *
 */

using System;
using System.Collections.Generic;

public class GoodsStrategy : EventStrategy {

    /**
     * Phrases for losing an item.
     */
    private String[] losePhrases = {"Your {0} fell out of your ship!", "A thief stole your {0}!",
            "Your {0} broke!",
            "Your {0} was in a freak cargo accident" + " and is no longer sellable!",
            "You can't seem to remember where you put that {0}..."};

    /**
     * Phrases for gaining an item.
     */
    private String[] getPhrases = {"You found {0} floating in space!",
            "A retiring trader gave you his last {0}!", "{0} fell from the sky into your hands!",
            "A shady looking man gave you his {0} and ran away!", "You found free {0} under a bush!"};


    
    public String execute(Player player) {

        Random rand = new Random();

        if (rand.NextDouble() > .5) {

            List<Good> items = Goods.Values;
            Good toAdd = items[rand.Next(items.Count)];

            int msg = rand.Next(getPhrases.Length);
            String output = String.Format(getPhrases[msg], toAdd.toString());

            if (player.cargoRoomLeft() >= 1) {
                player.addCargo(toAdd);
            } else {
                output = output.Substring(0, output.Length - 1);
                output += ", but you don't have room in your cargo for it!";
            }
            return output;
        } else {
            if (player.getCargo().Count > 0) {
                int cargoIndex = rand.Next(player.getCargo().Count);
                Good toRemove = player.getCargo()[cargoIndex];
                player.removeCargo(toRemove);
                int msg = rand.Next(losePhrases.Length);
                return String.Format(losePhrases[msg], toRemove.toString());
            } else {
                return "Your cargo hold broke open," + " but there was nothing in it!";
            }
        }
    }

}

