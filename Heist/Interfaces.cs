using System;

namespace Heist
{
    public interface IRobber
    {
        string Name {get;}
        int SkillLevel {get;}
        int Cut {get;}
        void PerformSkill(Bank bank){};
    }
}