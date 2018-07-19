

/**
 * This class is a Crew member on a ship. A Crew member contributes skills to the player's overall
 * total
 *
 * @author ngraves3
 *
 */
public class Crew : HasPrice, HasSkills {

    /**
     * The crew member's skills.
     */
    private SkillSet skills;

    /**
     * Constructor for the crew member.
     *
     * @param trade
     *        trade skill
     * @param fight
     *        fighting skill
     * @param eng
     *        engineering skill
     * @param pilot
     *        piloting skill
     * @param invest
     *        investing skill
     */
    public Crew(int trade, int fight, int eng, int pilot,
        int invest) {
        skills = new SkillSet(trade, fight, eng, pilot, invest);
    }

    
    public int getPrice() {
        //price for a crew member is 10 times his total skills; open to change
        return skills.totalSkill() * 10;
    }

    
    public int getTradeSkill() {
        return skills.getTradeSkill();
    }

    
    public int getEngineeringSkill() {
        return skills.getEngineeringSkill();
    }

    
    public int getPilotSkill() {
        return skills.getPilotSkill();
    }

    
    public int getFightingSkill() {
        return skills.getFightingSkill();
    }

    
    public int getInvestingSkill() {
        return skills.getInvestingSkill();
    }

}
