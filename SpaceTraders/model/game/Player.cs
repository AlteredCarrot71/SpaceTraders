using System;

namespace SpaceTraders
{
    // This class represents the Player and his state.
    public class Player : IHasSkills
    {
        // Name of character.
        public String Name { get; set; }

        // Skills of character.
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

        // Players money.
        public int Money { get; set; }

        // Player's ship.
        public Ship Ship { get; set; }

        // Consstrcutor for player.
        public Player() { }
    }
}
