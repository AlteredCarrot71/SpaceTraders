

/**
 * The abstraction of the Command design pattern. has an effect and it at can
 * either apply or remove that effect. It also enforces the variant th
 *
 * @author ngraves
 *
 */

using System;
using System.Collections.Generic;

public abstract class AbstractCommand : CommandPattern {

    /**
     * applyEffect := true, removeEffect := false.
     */
    private Stack<Boolean> stack = new Stack<Boolean>();

    /**
     * Applies the given effect.
     *
     * @return true if effect was applied, false otherwise
     */
    
    public bool applyEffect() {
        if (effect()) {
            stack.Push(true);
            return true;
        }
        return false;
    }

    /**
     * Undoes the effect.
     *
     * @return true if effect was undone, false otherwise
     */
    
    public bool removeEffect() {
        if (stack.Peek()) {
            if (uneffect()) {
                return stack.Pop(); //we know top of stack is 'true'
            }
        }

        return false;
    }

    /**
     * The actual effect that will be done.
     *
     * @return bool whether the effect was actually applied
     */
    protected abstract bool effect();

    /**
     * The way to remove the effect.
     *
     * @return bool whether the effect was actually removed
     */
    protected abstract bool uneffect();
}
