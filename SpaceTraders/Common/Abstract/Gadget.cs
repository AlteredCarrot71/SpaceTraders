using System;

namespace SpaceTraders.Abstract
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
    public abstract class Gadget : Abstract.Command, IHasPrice
    {
        // name of the gadget
        private readonly String name;

        // price of the gadget
        public int Price { get; set; }

        // The ship to affect
        protected Ship ship;

        // whether or not the effect was applied.
        protected bool effectApplied;

        // Constructor for an abstract gadget.
        protected Gadget(String nameArg, Ship shipArg)
        {
            this.ship = shipArg;
            this.name = nameArg;
            effectApplied = false;
        }

        protected Gadget()
        {
        }
    }
}
