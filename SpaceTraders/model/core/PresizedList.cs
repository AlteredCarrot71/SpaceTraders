using System;
using System.Collections.Generic;
/**
 * This class is used as backing data for most items in a Ship. It is
 * essentially an array with the nitty-gritty abstracted into add(T) and
 * remove(T). Chose not to implement List<T> because there were way too many
 * unecessary methods.
 *
 * USE THIS: http://docs.oracle.com/javase/7/docs/api/java/util/AbstractList.html
 *
 * @author Nick
 *
 * @param <T>
 */

public class PresizedList<T> : AbstractPresizedList<T> {

    /**
     * Backing array.
     */
    private T[] backing;

    /**
     * Size of list.
     */
    private int size;

    /**
     * Constructor for presized list.
     *
     * @param maxSize
     *        maximum size of list
     */
    public PresizedList(int maxSize) {
        backing = new T[maxSize];
        size = 0;
    }

    /**
     * Returns max size of list.
     *
     * @return max quantity of elements
     */
    
    public override int maxSize() {
        return backing.Length;
    }

    /**
     * Returns whether more elements can be added to this list.
     *
     * @return true iff the list has room
     */
    
    public override bool hasRoom() {
        return size < backing.Length;
    }

    
    public int Size {
        get { return size; }
    }

    
    public bool isEmpty() {
        return size == 0;
    }

    
    public new bool Add(T item) {
        if (null == item) 
        {
            throw new ArgumentException("Items can't be null");
        }
        if (size >= backing.Length)
        {
            return false;
        }
        backing[size] = item;
        size++;
        return true;
    }


    /**
     * Looks for the item in the list and removes it.
     *
     * @param item
     *        the item to remove from the list
     * @return the item if found, null otherwise
     * @throws IllegalArgumentException
     *         if item is null
     */
    private T removeHelper(T item) {
        
        if (item == null) {
            throw new ArgumentException("Items cannot be null");
        }
        
        T retval = default(T);
        int index = 0;
        while (retval == null && index < size && index < backing.Length) {
            if (item.Equals(backing[index])) {
                retval = backing[index];
                for (int j = index; j < (backing.Length - 1); j++) {
                    backing[j] = backing[j + 1];
                }
                backing[backing.Length - 1] = default(T);
            }
            index++;
        }
        return retval;
    }

    public bool remove(Object obj) {
        /**
        if (obj == null) {
            throw new IllegalArgumentException("Item cannot be null");
        }
        **/
        T item = (T) obj;

        T retval = removeHelper(item);
        if (retval != null) {
            size--;
        }
        return retval != null;
    }

    
    public T get(int index) {
        /**
        if (index >= size) {
            throw new IllegalArgumentException("Index out of range");
        }
        **/
        return backing[index];
    }
}
