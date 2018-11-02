// Interface to ensure skills are available for a Player/Crew.
namespace SpaceTraders
{
    public interface IHasSkills
    {
        // Trading skill.
        int TradeSkill { get; set; }

        // Engineering skill.
        int EngineeringSkill { get; set; }

        // Piloting skill.
        int PilotSkill { get; set; }

        // Fighting skill.
        int FightingSkill { get; set; }

        // Investing skill.
        //TODO: what is investing skill? and we need that?
        int InvestingSkill { get; set; }
    }
}
