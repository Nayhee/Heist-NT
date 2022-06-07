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
            
            Console.WriteLine($"Current Number of Operatives in the Rolodex: {rolodex.Count}");

            Console.Write("Enter the name of a new member you would like to add:");
            string newMemName = Console.ReadLine();
            Console.Write("Enter 1, 2, or 3 to select a specialty for the new member. ( 1 - Hacker (disables alarms), 2 - Muscle (disarms guards), 3 - Lock Specialist (cracks vault)): ");
            int newMemSpecialty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new members skill level (1 - 100): ");
            int newMemSkillLevel = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the % cut for the new member: ");
            int newMemberCut = int.Parse(Console.ReadLine());
            
            switch(newMemSpecialty)
            {
                case 1:
                {
                    rolodex.Add(new Hacker {Name = $"{newMemNam}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                    break;
                }
                case 2:
                {
                    rolodex.Add(new Muscle {Name = $"{newMemNam}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                    break;
                }
                case 3:
                {
                    rolodex.Add(new LockSpecialist {Name = $"{newMemNam}", SkillLevel = newMemSkillLevel, PercentageCut = newMemberCut});
                    break;
                }
            }
            
            List<Member> MemberList = new List<Member>();

            AddNewMember(); 

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

                foreach(Member mem in MemberList)
                {
                    TeamSkillSum += mem.SkillLevel;
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

            // void AddNewMember()
            // {
            //     Console.WriteLine("Please enter your team member's name");
            //     string MemberNameFromUser = Console.ReadLine();

            //     if(MemberNameFromUser != "")
            //     {
            //         Console.WriteLine("Please enter your team member's skill level");
            //         int SkillLevelFromUser = int.Parse(Console.ReadLine());
            //         Console.WriteLine("Please enter your team member's courage factor (0.0 - 2.0)");
            //         decimal CourageFromUser = decimal.Parse(Console.ReadLine());

            //         Member member = new Member(MemberNameFromUser, SkillLevelFromUser, CourageFromUser);
            //         MemberList.Add(member);

            //         Console.WriteLine("---------------------------------------------------------------------");
            //         Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}.");
            //         Console.WriteLine("---------------------------------------------------------------------");
                
            //         Console.Write("Want to add another Team mate? (y/n)  ");
            //         string Response = Console.ReadLine();
            //         if(Response.ToLower() == "y")
            //         {
            //             AddNewMember();
            //         }
            //         else
            //         {
            //             return;
            //         }
            //     }
            //     else
            //     {
            //         return;
            //     }
            // }          
        
        }
    }
}
