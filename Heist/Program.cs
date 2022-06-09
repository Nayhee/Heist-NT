using System;
using System.Collections.Generic;
using System.Linq;

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
                    Cut = 10
                },
                new Hacker()
                {
                    Name = "Dr. Flop",
                    SkillLevel = 130,
                    Cut = 10
                },
                new Muscle()
                {
                    Name = "Dr. Strong",
                    SkillLevel = 85,
                    Cut = 5
                },
                new Muscle()
                {
                    Name = "Mr. Strong",
                    SkillLevel = 95,
                    Cut = 5
                },
                new LockSpecialist()
                {
                    Name = "Dr. Lock",
                    SkillLevel = 125,
                    Cut = 15
                },
                new LockSpecialist()
                {
                    Name = "Mr. Lock",
                    SkillLevel = 105,
                    Cut = 10
                }
            };

            Console.WriteLine($"Current Number of Operatives in the Rolodex: {rolodex.Count}");
            
            AddNewMember();

            Bank BOA = new Bank()
            {
                AlarmScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000)
            };

            ReconReport(BOA);

            for(int i = 0; i <= rolodex.Count; i++)
            {
                Console.WriteLine($"{i}) {rolodex[i].Name} is a {rolodex[i].Specialty} with a skill level of {rolodex[i].SkillLevel}, and their cut is {rolodex[i].Cut}%. ");
                Console.WriteLine("--------------------------------");
            }

            List<IRobber> crew = new List<IRobber>();

            Console.WriteLine("Enter the index of the operative you'd like to include in your heist.");
            int opNum = int.Parse(Console.ReadLine());


            //what if we just get the index of the highest number, and the index of the lowest number.
            //we already know what order they in, so if we get those indexes, we know which are what. 
            void ReconReport(Bank bank)
            {            
                // List<int> scoreList = new List<int>()
                // {
                //     bank.AlarmScore, bank.VaultScore, bank.SecurityGuardScore
                // };
                // int maxNumIndex = scoreList.IndexOf(scoreList.Max());
                // int minNumIndex = scoreList.IndexOf(scoreList.Min());


                
                if(bank.AlarmScore > bank.VaultScore && bank.AlarmScore > bank.SecurityGuardScore)
                {
                    if(bank.VaultScore > bank.SecurityGuardScore)
                    {
                        Console.WriteLine("Most Secure: Alarm. Least Secure: SecurityGuard. ");
                    }
                    else
                    {
                        Console.WriteLine("Most Secure: Alarm. Least Secure: Vault. ");
                    }
                }
                else if(bank.VaultScore > bank.AlarmScore && bank.VaultScore > bank.SecurityGuardScore)
                {
                    if(bank.AlarmScore > bank.SecurityGuardScore)
                    {
                        Console.WriteLine("Most Secure: Vault. Least secure: SecurityGuard. ");
                    }
                    else
                    {
                        Console.WriteLine("Most Secure: Vault. Least secure: Alarm. ");
                    }
                }
                else
                {
                    if(bank.AlarmScore > bank.VaultScore)
                    {
                        Console.WriteLine("Most Secure: SecurityGuard. Least secure: Vault. ");
                    }
                    else 
                    {
                        Console.WriteLine("Most Secure: SecurityGuard. Least secure: Alarm. ");
                    }
                }
            }
            
            
            void AddNewMember()
            {
                Console.Write("Enter the name of a new member you would like to add: ");
                string newMemName = Console.ReadLine();

                if(newMemName != "")
                {
                    Console.WriteLine("Enter 1, 2, or 3 to select a specialty for the new member. ( 1 - Hacker (disables alarms), 2 - Muscle (disarms guards), 3 - Lock Specialist (cracks vault)): ");
                    int newMemSpecialty = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new members skill level (1 - 100): ");
                    int newMemSkillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter the % cut for the new member: ");
                    int newMemCut = int.Parse(Console.ReadLine());
                    
                    switch(newMemSpecialty)
                    {
                        case 1:
                        {
                            rolodex.Add(new Hacker {Name = newMemName, SkillLevel = newMemSkillLevel, Cut = newMemCut});
                            break;
                        }
                        case 2:
                        {
                            rolodex.Add(new Muscle {Name = newMemName, SkillLevel = newMemSkillLevel, Cut = newMemCut});
                            break;
                        }
                        case 3:
                        {
                            rolodex.Add(new LockSpecialist {Name = newMemName, SkillLevel = newMemSkillLevel, Cut = newMemCut});
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



            // Console.WriteLine("How many trial runs would you like to try?");
            // int TrialRuns = int.Parse(Console.ReadLine());
            // Console.WriteLine("Please Enter the Banks Difficulty Level.");
            // int BankDifficultyLevel = int.Parse(Console.ReadLine());
            // int Mirror = BankDifficultyLevel; //set additional variable equal to initial value of BankDifficultyLevel. 
            
            // int successfulRuns = 0;
            // int unsuccessfulRuns = 0;
            // int TeamSkillSum = 0;

            // for(int i=0; i<TrialRuns; i++)
            // {
            //     AttemptHeist();
            // }
            // Console.WriteLine($"Post-Heist Summary: {successfulRuns} successful heists and {unsuccessfulRuns} failed heists.");
            // Console.WriteLine("---------------------------------------------------");


            // void AttemptHeist()
            // {
            //     int luckValue = new Random().Next(-10,10);
            //     BankDifficultyLevel += luckValue;

            //     foreach(IRobber robber in rolodex)
            //     {
            //         TeamSkillSum += robber.SkillLevel;
            //     }
            //     Console.WriteLine($"Your team's combined skill level is {TeamSkillSum}.");
            //     Console.WriteLine($"The bank's difficulty level is {BankDifficultyLevel}.");
            //     if(TeamSkillSum > BankDifficultyLevel)
            //     {
            //         Console.WriteLine("SUCCESS! Your team's skill level was greater than the bank's difficulty!");
            //         successfulRuns++;
            //     }
            //     else
            //     {
            //         Console.WriteLine("FAILURE! Your team's skill level was less than the bank's difficulty.");
            //         unsuccessfulRuns++;
            //     }
            //     Console.WriteLine("---------------------------------------------------");

            //     BankDifficultyLevel = Mirror;
            //     TeamSkillSum = 0;
            // }

            
        
        }
    }
}
