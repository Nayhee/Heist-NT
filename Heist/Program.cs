using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
        
            List<Member> MemberList = new List<Member>();
            int successfulRuns = 0;
            int unsuccessfulRuns = 0;

            AddNewMember();
            DisplayNumOfMembers();

            Console.WriteLine("How many trial runs would you like to try?");
            int TrialRuns = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Banks Difficulty Level.");
            int BankDifficultyLevel = int.Parse(Console.ReadLine());

            int BankDifficultyCheck = BankDifficultyLevel;
            int TeamSkillSum = 0;

            for(int i=0; i<TrialRuns; i++)
            {
                AttemptHeist();
            }
            Console.WriteLine($"Heist Summary: Your team completed {successfulRuns} successful heists and {unsuccessfulRuns} failed heists.");
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

                BankDifficultyLevel = BankDifficultyCheck;
                TeamSkillSum = 0;
            }


            void AddNewMember()
            {
                Console.WriteLine("Please enter your team member's name");
                string MemberNameFromUser = Console.ReadLine();

                if(MemberNameFromUser != "")
                {
                    Console.WriteLine("Please enter your team member's skill level");
                    int SkillLevelFromUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter your team member's courage factor (0.0 - 2.0)");
                    decimal CourageFromUser = decimal.Parse(Console.ReadLine());

                    Member member = new Member(MemberNameFromUser, SkillLevelFromUser, CourageFromUser);
                    MemberList.Add(member);

                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}.");
                    Console.WriteLine("---------------------------------------------------------------------");
                
                    Console.Write("Want to add another Team mate? (y/n)  ");
                    string Response = Console.ReadLine();
                    if(Response.ToLower() == "y")
                    {
                        AddNewMember();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            void DisplayNumOfMembers()
            {
                Console.WriteLine($"Numer of Members: {MemberList.Count}");
            }            
        
        }
    }
}
