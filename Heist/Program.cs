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

            AddNewMember();
            DisplayMemberList();



            void DisplayMemberList()
            {
                Console.WriteLine("Member List:");

                foreach(Member mem in MemberList)
                {
                    Console.WriteLine($"{mem.Name}");
                }
            }

            

            void AddNewMember()
            {
                Console.WriteLine("Please enter your team member's name");
                string MemberNameFromUser = Console.ReadLine();
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

            
        
        }
    }
}
