using System;

namespace Heist
{
    public class Bank
    {
        public int CashOnHand {get; set;}
        public int AlarmScore {get; set;}
        public int VaultScore {get; set;}
        public int SecurityGuardScore {get; set;}

        protected bool IsSecure(){return AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0 ? true : false;}
    }
}
