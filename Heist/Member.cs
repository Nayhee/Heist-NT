using System;
using System.Collections.Generic;

namespace Heist
{
    public class Member
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public decimal CourageFactor {get; set;}

        public Member(string name, int skillLevel, decimal courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }
     
    }
}