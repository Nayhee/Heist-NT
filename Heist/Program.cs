using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
        
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name = "Mr. Flop",
                    SkillLevel = 110,
                    PercentageCut = 10
                },
                new Hacker()
                {
                    Name = "Dr. Flop",
                    SkillLevel = 130,
                    PercentageCut = 10
                },
                new Muscle()
                {
                    Name = "Dr. Strong",
                    SkillLevel = 85,
                    PercentageCut = 5
                },
                new Muscle()
                {
                    Name = "Mr. Strong",
                    SkillLevel = 95,
                    PercentageCut = 5
                },
                new LockSpecialist()
                {
                    Name = "Dr. Lock",
                    SkillLevel = 125,
                    PercentageCut = 15
                },
                new LockSpecialist()
                {
                    Name = "Mr. Lock",
                    SkillLevel = 105,
                    PercentageCut = 10
                }
            };

            void AddNewMember()
            {
                Console.WriteLine($"Current Number of Operatives in the Rolodex: {rolodex.Count}");

                Console.Write("Enter the name of a new member you would like to add: ");
                string newMemName = Console.ReadLine();

                if(newMemName != "")
                {
                    Console.WriteLine("Enter 1, 2, or 3 to select a specialty for the new member. ( 1 - Hacker (disables alarms), 2 - Muscle (disarms guards), 3 - Lock Specialist (cracks vault)): ");
                    int newMemSpecialty = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new members skill level (1 - 100): ");
                    int newMemSkillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter the % cut for the new member: ");
                    int newMemberCut = int.Parse(Console.ReadLine());
                    
                    switch(newMemSpecialty)
                    {
                        case 1:
                        {
                            rolodex.Add(new Hacker {Name = $"{newMemName}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                            break;
                        }
                        case 2:
                        {
                            rolodex.Add(new Muscle {Name = $"{newMemName}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                            break;
                        }
                        case 3:
                        {
                            rolodex.Add(new LockSpecialist {Name = $"{newMemName}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                            break;
                        }
                    }
                    Console.WriteLine("Would you like to add another member? (Y/N) ");
                    string userResponse = Console.ReadLine();
                    if(userResponse.ToLower() == "y")
                    {
                        AddNewMember();
                    }
                }
            }

    
            
            

            Console.WriteLine("How many trial runs would you like to try?");
            int TrialRuns = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Banks Difficulty Level.");
            int BankDifficultyLevel = int.Parse(Console.ReadLine());
            int Mirror = BankDifficultyLevel; //set additional variable equal to initial value of BankDifficultyLevel. 
            
            int successfulRuns = 0;
            int unsuccessfulRuns = 0;
            int TeamSkillSum = 0;

            for(int i=0; i<TrialRuns; i++)
            {
                AttemptHeist();
            }
            Console.WriteLine($"Post-Heist Summary: {successfulRuns} successful heists and {unsuccessfulRuns} failed heists.");
            Console.WriteLine("---------------------------------------------------");


            void AttemptHeist()
            {
                int luckValue = new Random().Next(-10,10);
                BankDifficultyLevel += luckValue;

                foreach(IRobber robber in rolodex)
                {
                    TeamSkillSum += robber.SkillLevel;
                }
                Console.WriteLine($"Your team's combined skill level is {TeamSkillSum}.");
                Console.WriteLine($"The bank's difficulty level is {BankDifficultyLevel}.");
                if(TeamSkillSum > BankDifficultyLevel)
                {
                    Console.WriteLine("SUCCESS! Your team's skill level was greater than the bank's difficulty!");
                    successfulRuns++;
                }
                else
                {
                    Console.WriteLine("FAILURE! Your team's skill level was less than the bank's difficulty.");
                    unsuccessfulRuns++;
                }
                Console.WriteLine("---------------------------------------------------");

                BankDifficultyLevel = Mirror;
                TeamSkillSum = 0;
            }

            
        
        }
    }
}
