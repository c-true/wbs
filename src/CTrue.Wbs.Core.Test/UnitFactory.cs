using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrue.Wbs.Core.Test
{
    static class UnitFactory
    {
        public static Unit Createguardsman()
        {
            return new Unit()
            {

                Name = "Guardsman",
                Movement = 6,
                WeaponSkill = 4,
                BallisticSkill = 4,
                Strength = 3,
                Toughness = 3,
                Wounds = 1,
                Attack = 1,
                Leadership = 6,
                Save = 5,
            };
        }
        public static Unit Createfirewarrior()
        {
            return new Unit()
            {
                Name = "Fire Warrior",
                Movement = 6,
                WeaponSkill = 5,
                BallisticSkill = 4,
                Strength = 3,
                Toughness = 3,
                Wounds = 1,
                Attack = 1,
                Leadership = 6,
                Save = 4,
            };
        }

        public static Weapon Createlasgun()
        {
            return new Weapon
            {
                Name = "Lasgun",
                Range = 24,
                Strength = 3,
                RapidFire = 1,
                ArmourPenetration = 0
            };

        }
    }
}
