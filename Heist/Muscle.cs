using System;

namespace Heist
{
    public class Muscle : Member, IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public int Cut {get; set;}
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            Console.WriteLine($"{Name} is taking out the security guards. Decreased security by {SkillLevel}.");
            if(bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully taken out all the security guards.");
            }
        }
        public string Specialty = "Muscle";
    }

}