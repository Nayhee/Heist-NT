using System;

namespace Heist
{
    public class LockSpecialist : Member, IRobber
    {
        //Inherits 1) Name, 2) SkillLevel from Member class.
        public int Cut {get; set;}
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            Console.WriteLine($"{Name} is cracking the Vault. Decreased vault security by {SkillLevel}.");
            if(bank.VaultScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully cracked the vault.");
            }
        }
        public string Specialty = "Lock Specialist";
    }

}