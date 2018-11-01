using System;

// Represents a coordinate position for a SolarSystem.
public class Point
{

    public int Xpos { get; set; }
    public int Ypos { get; set; }

    // Constructor.
    public Point() { }

    // Returns the distance between 2 points. Casts hypotenuse to an int.
    public int Distance(Point other)
    {
        return (int) Math.Sqrt(Math.Pow((Xpos - other.Xpos), 2)
                        + Math.Pow((Ypos - other.Ypos), 2));
    }

    public int HashCode()
    {
        return Xpos * Ypos;
    }
}
