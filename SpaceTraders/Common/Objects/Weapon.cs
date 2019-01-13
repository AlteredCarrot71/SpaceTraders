using System;

namespace SpaceTraders
{
    public class Weapon : IHasPrice
    {
        public String Name { get; set; }
        public int Price { get; set; }
        public TechLevel MinTechLevel { get; set; }
        public int SkillModifier { get; set; }

        public Weapon() { }
    }
}
