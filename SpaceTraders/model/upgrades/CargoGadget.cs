using System.Collections.Generic;

/**
 * This class represents an object that adds extra cargo to a Ship. It uses the
 * command pattern to do/undo changes
 *
 * @author ngraves3
 *
 */

namespace SpaceTraders
{
    public class CargoGadget : AbstractGadget
    {
        // The extra size added.
        private readonly int additionalSize;

        /**
         * Constructor for the gadget.
         *
         * @param ship
         *        the ship to affect.
         * @param additionalSizeArg
         *        the extra size to add
         */
        public CargoGadget(Ship ship, int additionalSizeArg)
            : base("Extra Cargo Bay", ship)
        {
            additionalSize = additionalSizeArg;
        }

        /**
         * Default size constructor.
         *
         * @param ship
         *        the ship to affect
         */
        public CargoGadget(Ship ship) : this(ship, 5)
        {
        }

        new public readonly int Price = 1000;

        protected override bool Effect()
        {
            if (!effectApplied)
            {
                effectApplied = true;
                //TODO: add cargo room to ship
                IList<Good> currentCargo = ship.Cargo;
                PresizedList<Good> bigger =
                                new PresizedList<Good>(ship.MaxCargo + additionalSize);
                foreach (Good cargo in currentCargo)
                {
                    bigger.Add(cargo);
                }
                ship.Cargo = bigger;
                return true;
            }

            return false;
        }

        protected override bool Uneffect()
        {
            if (effectApplied)
            {
                IList<Good> currentCargo = ship.Cargo;
                if ((ship.MaxCargo - additionalSize) >= currentCargo.Count)
                {
                    PresizedList<Good> smaller =
                                    new PresizedList<Good>(ship.MaxCargo - additionalSize);
                    foreach (Good cargo in currentCargo)
                    {
                        smaller.Add(cargo);
                    }

                    // Apply effect
                    ship.Cargo = smaller;
                    effectApplied = false;
                    return true;
                }
                else
                {
                    //too much cargo to remove additional space
                    return false;
                }
            }

            return false;
        }
    }
}
