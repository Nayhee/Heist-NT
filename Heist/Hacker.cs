using System;

namespace Heist
{
    public class Hacker : Member, IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public int Cut {get; set;}
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased alarm security by {SkillLevel}.");
            if(bank.AlarmScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully disabled the alarm system.");
            }
        }
        public string Specialty = "Hacker";
    }

}