// This class holds all the specs for skills in a Player/Crew.

public class SkillSet {

    // Skills
    public int Trading { get; private set; }
    public int Fighting { get; private set; }
    public int Engeneering { get; private set; }
    public int Piloting { get; private set; }
    public int Investing { get; private set; }

    // Constructor for skill set.
    public SkillSet(int trade, int fight, int eng, int pilot, int invest) {
        Trading = trade;
        Fighting = fight;
        Engeneering = eng;
        Piloting = pilot;
        Investing = invest;
    }

    // Returns the total number of skill points represented by this set of skills.
    public int TotalSkill() {
        return Trading + Fighting + Engeneering + Piloting + Investing;
    }

}
