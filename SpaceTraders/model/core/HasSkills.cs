// Interface to ensure skills are available for a Player/Crew.
namespace SpaceTraders
{
    public interface HasSkills
    {
        // Returns trading skill.
        int getTradeSkill();

        // Returns engineering skill.
        int getEngineeringSkill();

        // Returns piloting skill.
        int getPilotSkill();

        // Returns fighting skill.
        int getFightingSkill();

        // Returns investing skill.
        int getInvestingSkill();
    }
}
