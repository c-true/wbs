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

        public bool Wound(Weapon attackerWeapon, Unit defender)
        {
            int WoundRoll = _dice.Roll();
            if (WoundRoll == 1)
            {
                return false;
            }
            int requredwoundroll = Requredwoundroll(attackerWeapon.Strength, defender.Toughness);

            if (WoundRoll >= requredwoundroll)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int Requredwoundroll(int attackerWeaponStrength, int defenderToughness)
        {
            if (attackerWeaponStrength == defenderToughness)
            {
                return 4;
            }
           
            if (attackerWeaponStrength * 2 < defenderToughness)
            {
                return 6;
            }

            if (attackerWeaponStrength < defenderToughness)
            {
                return 5;
            }

            if (attackerWeaponStrength > defenderToughness * 2)
            {
                return 2;
            }

            if (attackerWeaponStrength > defenderToughness)
            {
                return 3;
            }

            return 4;

        }

        public bool WasSaved(Weapon attackerWeapon, Unit defender)
        {
            int saveRoll = _dice.Roll();

            if (saveRoll == 1)
            {
                return false;
            }

            saveRoll -= attackerWeapon.ArmourPenetration;

            return (saveRoll >= defender.Save);
            
         }
         
        /// <summary>
        /// This method checks if an attack kills a unit.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="attackerWeapon"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public bool WasDefenderKilled(Unit attacker, Weapon attackerWeapon, Unit defender)
        {
            bool wasHit = Hit(attacker, defender);
            if (wasHit == false)
                return false;

            bool wasWound = Wound(attackerWeapon, defender);
            if (wasWound == false)
                return false;

            bool wasSaved = WasSaved(attackerWeapon, defender);
            
            return !wasSaved;
        }
    }
}
