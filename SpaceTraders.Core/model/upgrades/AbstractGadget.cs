using System;

namespace SpaceTraders
{
    /**
     * An abstract representation of a gadget. Not much can be said about gadgets
     * because they all have different effects. the 3 implements effects will be:
     * added cargo room, cloaking device, and reduced fuel cost. Gadget implements
     * the Command design pattern
     *
     * @author ngraves3
     *
     */
    public abstract class AbstractGadget : AbstractCommand, HasPrice
    {

        /**
         * name of the gadget.
         */
        private String name;

        /**
         * The ship to affect.
         */
        protected Ship ship;

        /**
         * whether or not the effect was applied.
         */
        protected bool effectApplied;

        /**
         * Constructor for an abstract gadget.
         *
         * @param nameArg
         *        name of gadget
         * @param shipArg
         *        the ship to affect
         */

        protected AbstractGadget(String nameArg, Ship shipArg)
        {
            this.ship = shipArg;
            this.name = nameArg;
            effectApplied = false;
        }

        protected AbstractGadget()
        {
            ;
        }


        public String toString()
        {
            return Utilities.capitalize(name);
        }


        public abstract int getPrice();
    }
}
