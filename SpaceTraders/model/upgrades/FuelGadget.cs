
/**
 * This class is a gadget that reduces fuel cost for the ship.
 *
 * @author ngraves3
 *
 */

using System;

namespace SpaceTraders
{
    public class FuelGadget : AbstractGadget
    {
        // Divide current fuel cost by this amount.
        private int fuelModifier = 2;

        // Need to know original cost to avoid truncation errors.
        private int originalFuelCost;

        // Constructor for a fuel gadget.
        public FuelGadget(Ship ship)
            : base("Efficient Engine", ship)
        {
            originalFuelCost = ship.FuelCost;
        }

        public override int getPrice()
        {
            return 500;
        }

        protected override bool effect()
        {
            if (!effectApplied)
            {
                ship.FuelCost = Math.Max(1, originalFuelCost / fuelModifier);
                effectApplied = true;
                return true;
            }

            return false;
        }

        protected override bool uneffect()
        {
            if (effectApplied)
            {
                ship.FuelCost = originalFuelCost;
                effectApplied = false;
                return true;
            }
            return false;
        }
    }
}
