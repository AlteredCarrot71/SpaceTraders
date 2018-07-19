

/**
 * This class holds all the specs for skills in a Player/Crew.
 *
 * @author ngraves3
 *
 */
public class SkillSet : HasSkills {

    /**
     * trading skill.
     */
    private int tradeSkill;

    /**
     * fighting skill.
     */
    private  int fightSkill;

    /**
     * engineering skill.
     */
    private  int engSkill;

    /**
     * piloting skill.
     */
    private  int pilotSkill;

    /**
     * investing skill.
     */
    private  int investSkill;

    /**
     * Constructor for skill set.
     *
     * @param trade
     *        trade skill
     * @param fight
     *        fight skill
     * @param eng
     *        engineering skill
     * @param pilot
     *        piloting skill
     * @param invest
     *        invest skill
     */
    public SkillSet(int trade, int fight, int eng, int pilot, int invest) {
        tradeSkill = trade;
        fightSkill = fight;
        engSkill = eng;
        pilotSkill = pilot;
        investSkill = invest;
    }

    
    public int getTradeSkill() {
        return tradeSkill;
    }

    
    public int getEngineeringSkill() {
        return engSkill;
    }

    
    public int getPilotSkill() {
        return pilotSkill;
    }

    
    public int getFightingSkill() {
        return fightSkill;
    }

    
    public int getInvestingSkill() {
        return investSkill;
    }

    /**
     * Returns the total number of skill points represented by this set of skills.
     *
     * @return total number of skill points
     */
    public int totalSkill() {
        return tradeSkill + fightSkill + engSkill + pilotSkill + investSkill;
    }

}
