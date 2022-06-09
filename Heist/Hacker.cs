using System;

namespace Heist
{
    public class Hacker : IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public int Cut {get; set;}
        public string Specialty {get;} = "Hacker";
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased alarm security by {SkillLevel}.");
            if(bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has successfully disabled the alarm system.");
            }
        }
    }

}