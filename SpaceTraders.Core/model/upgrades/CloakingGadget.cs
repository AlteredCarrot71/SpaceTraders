

/**
 * The gadget the makes the player invisible to encounters.
 *
 * @author ngraves3
 *
 */
public class CloakingGadget : AbstractGadget {

    /**
     * Constructor for a cloaking gadget.
     *
     * @param ship
     *        the ship to affect
     */
    public CloakingGadget(Ship ship)
        : base("Stealth Generator", ship)
    { 
        ;
    }

    
    public override int getPrice() {
        //arbitrary number
        return 2000;
    }

    
    protected override bool effect() {
        if (effectApplied) return false;
        ship.Visible = false;
        effectApplied = true;
        return true;
    }

    
    protected override bool uneffect() {
        if (effectApplied) {
            ship.Visible  = true;
            effectApplied = false;
            return true;
        }

        return false;
    }

}
