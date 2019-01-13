// The gadget the makes the player invisible to encounters.
namespace SpaceTraders
{
    public class CloakingGadget : Abstract.Gadget
    {
        // Constructor for a cloaking gadget.
        public CloakingGadget(Ship ship)
            : base("Stealth Generator", ship)
        {
        }

        new public int Price = 2000;

        protected override bool Effect()
        {
            if (effectApplied) return false;
            ship.IsVisible = false;
            effectApplied = true;
            return true;
        }

        protected override bool Uneffect()
        {
            if (effectApplied)
            {
                ship.IsVisible = true;
                effectApplied = false;
                return true;
            }

            return false;
        }
    }
}