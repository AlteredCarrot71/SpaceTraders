

/**
 * The interface defining the Command design pattern. Can apply an effect or
 * undo an effect. This is the most bare and abstract representation
 *
 * @author ngraves3
 *
 */
public interface CommandPattern {

    /**
     * Applies the object's effect.
     *
     * @return true iff effect was applied, false otherwise
     */
    bool applyEffect();

    /**
     * Removes the object's effect.
     *
     * @return true iff the effect was removed, false otherwise
     */
    bool removeEffect();
}
