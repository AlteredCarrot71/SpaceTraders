

/**
 * A class representing shields for use in combat.
 * 
 * @author ngraves3
 *
 */

using System;

public static class Shield
{
    /**
     * A basic shield.
     */
    public static readonly Shie ENERGY_SHIELD = new Shie("Energy Shield", 0);
    /**
     * A premium shield.
     */
    public static readonly Shie REFLECTIVE_SHIELD = new Shie("Reflective Shield", 1);


}

public class Shie : HasPrice
{
    private int ord;
    private String name;

    public Shie(String name, int ord)
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
