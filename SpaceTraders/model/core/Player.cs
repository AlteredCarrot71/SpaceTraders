using System;
using System.Collections.Generic;

namespace SpaceTraders
{
    // This class represents the Player and his state.
    public class Player : HasSkills
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
 
        // Adds fuel to the player's ship and removes the appropriate amount of money from the player.
        public void BuyFuel()
        {
            int quantity = CalculateFuelQuantity();
            Ship.CurrentFuel += quantity;
            Money -= (quantity * Ship.FuelCost);
        }

        // Returns the total cost of refueling a ship.
         public int GetRefuelCost()
        {
            return CalculateFuelQuantity() * Ship.FuelCost;
        }

        // Calculates the amount of fuel a player can buy based on money and fuel cost.
        private int CalculateFuelQuantity()
        {
            int fuelAmount = Ship.MaxFuel - Ship.CurrentFuel;

            if ((fuelAmount * Ship.FuelCost) > Money)
            {
                fuelAmount = Money / Ship.FuelCost;
            }

            return fuelAmount;
        }

        public String GetInfo()
        {
            String term = "\n";
            String retval = "Name: " + Name + term;
            retval += "Piloting skill: " + getPilotSkill() + term;
            retval += "Fighting skill: " + getFightingSkill() + term;
            retval += "Engineering skill: " + getEngineeringSkill() + term;
            retval += "Trading Skill: " + getTradeSkill() + term;
            retval += "Investing Skill: " + getInvestingSkill() + term;
            retval += "Ship: " + Ship.Name;
            return retval;
        }

        // The below methods need to account for a Crew members skill too
        public int getTradeSkill()
        {
            int total = Skills.Trading;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Trading;
            }
            return total;
        }

        public int getEngineeringSkill()
        {
            int total = Skills.Engineering;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Engineering;
            }
            return total;
        }

        public int getPilotSkill()
        {
            int total = Skills.Piloting;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Piloting;
            }
            return total;
        }

        public int getFightingSkill()
        {
            int total = Skills.Fighting;
            foreach (Crew member in Ship.getCrew())
            {
                total += member.Skills.Fighting;
            }
            return total;
        }

        public int getInvestingSkill()
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