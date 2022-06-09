using System;

namespace Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name {get; set;}
        public int SkillLevel {get; set;}
        public int Cut {get; set;}
        public string Specialty {get;} = "Lock Specialist";
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the Vault. Decreased vault security by {SkillLevel}.");
            if(bank.VaultScore <= 0)
            {
                Console.WriteLine($"Mr. {Name} has successfully cracked the vault.");
            }
        }
    }

}