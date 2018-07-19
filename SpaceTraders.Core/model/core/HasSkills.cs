

/**
 * Interface to ensure skills are available for a Player/Crew.
 *
 * @author ngraves3
 *
 */
public interface HasSkills {

    /**
     * Returns trading skill.
     *
     * @return int of trading skill
     */
    int getTradeSkill();

    /**
     * Returns engineering skill.
     *
     * @return int of engineering skill
     */
    int getEngineeringSkill();

    /**
     * Returns piloting skill.
     *
     * @return int of piloting skill
     */
    int getPilotSkill();

    /**
     * Returns fighting skill.
     *
     * @return int of piloting skill
     */
    int getFightingSkill();

    /**
     * Returns investing skill.
     *
     * @return int of investing skill
     */
    int getInvestingSkill();

}
