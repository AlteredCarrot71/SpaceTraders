using System;
using System.Collections.Generic;

namespace SpaceTraders
{
    // This class represents the Player and his state.
    public class Player : IHasSkills
    {
        // Nameof character.
        public String Name { get; set; }

        // Skills of character.
        public SkillSet Skills { get; set; }

        // Players money.
        public int Money { get; set; }

        // Player's ship.
        public Ship Ship { get; set; }

        // Consstrcutor for player.
        public Player() { }

        // Returns a list of the current upgrades of the ship.
        public IList<HasPrice> GetUpgrades()
        {
            IList<HasPrice> upgrades = new List<HasPrice>();
        
            foreach (HasPrice weapon in Ship.getWeapons())
            {
                upgrades.Add(weapon);
            }
        
            foreach (HasPrice shield in Ship.getShields())
            {
                upgrades.Add(shield);
            }
        
            foreach (Crew crew in Ship.getCrew())
            {
                upgrades.Add(crew);
            }
        
            foreach (AbstractGadget gadget in Ship.getGadgets())
            {
                upgrades.Add(gadget);
            }
        
            return upgrades;
        }
 
        // The below methods need to account for a Crew members skill too
        public int TradeSkill()
        {
            int total = Skills.Trading;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Trading;
            }
            return total;
        }

        public int EngineeringSkill()
        {
            int total = Skills.Engineering;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Engineering;
            }
            return total;
        }

        public int PilotSkill()
        {
            int total = Skills.Piloting;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Piloting;
            }
            return total;
        }

        public int FightingSkill()
        {
            int total = Skills.Fighting;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Fighting;
            }
            return total;
        }

        public int InvestingSkill()
        {
            int total = Skills.Investing;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Investing;
            }
            return total;
        }
    }
}