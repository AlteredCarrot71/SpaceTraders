// This class is a Crew member on a ship. A Crew member contributes skills to the player's overall total

public class Crew
{
    // The crew member's skills.
    public SkillSet Skills { get; set; }

    // Constructor for the crew member.
    public Crew() { }

    public int getPrice()
    {
        //price for a crew member is 10 times his total skills; open to change
        return Skills.TotalSkill() * 10;
    }
}
