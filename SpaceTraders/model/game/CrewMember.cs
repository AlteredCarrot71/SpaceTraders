using System;

// This class is a Crew member on a ship. A Crew member contributes skills to the player's overall total
namespace SpaceTraders
{
    public class CrewMember : IHasSkills, HasPrice
    {
        // The crew member's name
        public String Name { get; set; }

        // The crew member's skills
        // Trading skill.
        public int TradeSkill { get; set; }

        // Engineering skill.
        public int EngineeringSkill { get; set; }

        // Piloting skill.
        public int PilotSkill { get; set; }

        // Fighting skill.
        public int FightingSkill { get; set; }

        // Investing skill.
        public int InvestingSkill { get; set; }

        // Constructor for the crew member.
        public CrewMember() { }

        public int getPrice()
        {
            //price for a crew member is 10 times his total skills; open to change
            return ( TradeSkill + EngineeringSkill + PilotSkill + FightingSkill + InvestingSkill ) * 10;
        }
    }
}
