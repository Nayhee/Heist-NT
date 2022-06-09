using System;

namespace Heist
{
    public class Muscle : IRobber
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public int Cut {get; set;}
        public string Specialty {get;} = "Muscle";
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is taking out the security guards. Decreased security by {SkillLevel}.");
            if(bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully taken out all the security guards.");
            }
        }
    }

}