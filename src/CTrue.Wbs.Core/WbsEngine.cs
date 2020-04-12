using System;
using System.Collections.Generic;
using System.Text;

namespace CTrue.Wbs.Core
{
    public class WbsEngine
    {
        public WbsEngine(IDice dice)
        {
            _dice = dice;
        }

        private IDice _dice;

        public bool Hit(Unit attacker, Unit defender)
        {
  

            int HitRoll = _dice.Roll();

            if (HitRoll >= attacker.BallisticSkill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
