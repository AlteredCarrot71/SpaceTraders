using System.Collections.Generic;
using System.Collections.ObjectModel;

/**
 * The abstract class describing the operations of a PresizedList. A PresizedList has a maxSize and
 * a hasRoom method
 *
 * @author ngraves3
 *
 * @param <T>
 *        the type of object in the list
 */
public abstract class AbstractPresizedList<T> : List<T>
{
    // Returns whether another item can be added to the list.
    public abstract bool hasRoom();

    // Returns the max size of the list.
    public abstract int maxSize();
}
