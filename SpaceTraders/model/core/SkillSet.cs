// This class holds all the specs for skills in a Player/Crew.

public class SkillSet
{
    // Skills
    public int Trading { get; set; }
    public int Fighting { get; set; }
    public int Engineering { get; set; }
    public int Piloting { get; set; }
    public int Investing { get; set; }

    // Constructor for skill set.
    public SkillSet() { }

    // Returns the total number of skill points represented by this set of skills.
    public int TotalSkill()
    {
        return Trading + Fighting + Engineering + Piloting + Investing;
    }
}
