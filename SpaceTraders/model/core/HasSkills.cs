// Interface to ensure skills are available for a Player/Crew.
namespace SpaceTraders
{
    public interface IHasSkills
    {
        // Returns trading skill.
        int TradeSkill();

        // Returns engineering skill.
        int EngineeringSkill();

        // Returns piloting skill.
        int PilotSkill();

        // Returns fighting skill.
        int FightingSkill();

        // Returns investing skill.
        //TODO: what is investing skill? and we need that?
        int InvestingSkill();
    }
}
