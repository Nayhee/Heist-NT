using System;

namespace Heist
{
    public class Muscle : Member, IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public int PercentageCut {get; set;}
        public void PerformSkill(Bank bank)
        {
            SecurityGuardScore = SecurityGuardScore - SkillLevel;
            Console.WriteLine($"{Name} is taking out the security guards. Decreased security by {SkillLevel}.");
            if(SecurityGuardScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully taken out all the security guards.");
            }
        }
    }

}