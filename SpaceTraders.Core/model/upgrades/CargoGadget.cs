

/**
 * This class represents an object that adds extra cargo to a Ship. It uses the
 * command pattern to do/undo changes
 *
 * @author ngraves3
 *
 */

using System.Collections.Generic;

public class CargoGadget : AbstractGadget {

    /**
     * The extra size added.
     */
    private int additionalSize;

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
        ;
    }

    
    public override int getPrice() {
        // arbitrary number
        return 1000;
    }

    
    protected override bool effect() {
        if (!effectApplied) {
            effectApplied = true;
            //TODO add cargo room to ship
            IList<Good> currentCargo = ship.getCargo();
            PresizedList<Good> bigger =
                            new PresizedList<Good>(ship.cargoSize() + additionalSize);
            foreach (Good cargo in currentCargo) {
                bigger.Add(cargo);
            }
            ship.setCargo(bigger);
            return true;
        }

        return false;

    }

    
    protected override bool uneffect() {
        if (effectApplied) {
            IList<Good> currentCargo = ship.getCargo();
            if ((ship.cargoSize() - additionalSize) >= currentCargo.Count) {
                PresizedList<Good> smaller =
                                new PresizedList<Good>(ship.cargoSize() - additionalSize);
                foreach (Good cargo in currentCargo) {
                    smaller.Add(cargo);
                }

                /*
                 * Apply effect
                 */

                ship.setCargo(smaller);
                effectApplied = false;
                return true;

            } else {
                //too much cargo to remove additional space
                return false;
            }
        }

        return false;

    }

}
