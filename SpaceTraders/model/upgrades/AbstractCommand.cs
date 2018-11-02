using System;
using System.Collections.Generic;

/**
 * The abstraction of the Command design pattern. has an effect and it at can
 * either apply or remove that effect. It also enforces the variant th
 *
 * @author ngraves
 *
 */

public abstract class AbstractCommand : ICommandPattern
{
    // applyEffect := true, removeEffect := false.
    private Stack<Boolean> stack = new Stack<Boolean>();

    /**
     * Applies the given effect.
     *
     * @return true if effect was applied, false otherwise
     */
    public bool ApplyEffect()
    {
        if (Effect()) {
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
    public bool RemoveEffect()
    {
        if (stack.Peek())
        {
            if (Uneffect())
            {
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
    protected abstract bool Effect();

    /**
     * The way to remove the effect.
     *
     * @return bool whether the effect was actually removed
     */
    protected abstract bool Uneffect();
}
