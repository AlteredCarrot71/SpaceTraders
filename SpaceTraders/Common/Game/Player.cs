using System;

namespace SpaceTraders
{
    // This class represents the Player and his state.
    public class Player : Abstract.CrewMember
    {
        // Players money.
        public int Money { get; set; }

        // Player's ship.
        public Ship Ship { get; set; }

        // Constrcutor for player.
        public Player() { }
    }
}
