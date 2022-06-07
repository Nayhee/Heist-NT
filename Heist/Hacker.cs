using System;

namespace Heist
{
    public class Hacker : Member, IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public int PercentageCut {get; set;}
        public void PerformSkill(Bank bank)
        {
            AlarmScore = AlarmScore - SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased alarm security by {SkillLevel}.");
            if(AlarmScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully disabled the alarm system.");
            }
        }
    }

}