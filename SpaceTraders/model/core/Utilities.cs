using System;

/**
 * Class containing lots of useful methods for various things that don't really belong in a class.
 *
 * @author ngraves3
 *
 */
namespace SpaceTraders
{
    public static class Utilities
    {
        // Capitalizes a string.
        public static String Capitalize(String str)
        {
            if (str == null)
            {
                return null;
            }
            else if (str.Length == 0)
            {
                return str;
            }
            else if (str.Length == 1)
            {
                return str.ToUpper();
            }
            else
            {
                return str[0] + str.Substring(1, str.Length).ToLower();
            }
        }
    }
}
