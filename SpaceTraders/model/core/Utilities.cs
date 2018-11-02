using System;

/**
 * Class containing lots of useful methods for various things that don't really belong in a class.
 *
 * @author ngraves3
 *
 */

public class Utilities
{
    /**
     * Capitalizes a string.
     *
     * @param str
     *        the string to capitalize
     * @return the capitalized string; null if input is null; empty string if string is empty
     */
    public static String capitalize(String str) {
        if (str == null) {
            return null;
        }

        if (str.Length == 0) {
            return str;
        }
        if (str.Length == 1) {
            return str.ToUpper();
        }

        return str[0] + str.Substring(1, str.Length).ToLower();
    }
}
