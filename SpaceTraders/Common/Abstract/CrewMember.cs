// This class is a Crew member on a ship. A Crew member contributes skills to the player's overall total
namespace SpaceTraders.Abstract
{
    public class CrewMember : Item
    {
        // The crew member's skills
        // Trading skill.
        public int TradeSkill { get; set; }

        // Engineering skill.
        public int EngineeringSkill { get; set; }

        // Piloting skill.
        public int PilotSkill { get; set; }

        // Fighting skill.
        public int FightingSkill { get; set; }

        // Constructor for the crew member.
        public CrewMember() { }
    }
}
