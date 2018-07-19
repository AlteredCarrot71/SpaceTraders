

/**
 * A class representing a weapon for combat.
 *
 * @author ngraves3
 *
 */

using System;

public static class Weapon 
{
    /**
     * A standard laser.
     */
    public static readonly Weap PULSE_LASER = new Weap("Pulse Laser", 0);
    /**
     * A better laser.
     */
    public static readonly Weap BEAM_LASER = new Weap("Beam Laser", 1);
    /**
     * The best laser.
     */
    public static readonly Weap MILITARY_LASER = new Weap("Military Laser", 2);
}

public class Weap : HasPrice
{
    private int ord;
    private String name;

    public Weap(String name, int ord)
    {
        this.name = name;
        this.ord = ord;
    }

    public int getPrice()
    {
        return 500*(ord + 1);
    }


    public String toString()
    {
        return name;
    }

}
