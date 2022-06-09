using System;

namespace Heist
{
    public interface IRobber
    {
        string Name {get;}
        string Specialty {get;}
        int SkillLevel {get;}
        int Cut {get;}
        void PerformSkill(Bank bank){}
    }
}