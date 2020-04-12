using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;

namespace CTrue.Wbs.Core.Test
{
   [TestFixture]
    public class WbsEngineTest
    {
        [Test]
        public void Test()
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(5);

            WbsEngine engine = new WbsEngine(dice) ;

            Unit guardsman = new Unit();
            guardsman.Name = "Guardsman";
            guardsman.Movement = 6;
            guardsman.WeaponSkill = 4;
            guardsman.BallisticSkill = 4;
            guardsman.Strength = 3;
            guardsman.Toughness = 3;
            guardsman.Wounds = 1;
            guardsman.Attack = 1;
            guardsman.Leadership = 6;
            guardsman.Save = 5;

            Unit fireWarrior = new Unit();
            fireWarrior.Name = "Fire Warrior";
            fireWarrior.Movement = 6;
            fireWarrior.WeaponSkill = 5;
            fireWarrior.BallisticSkill = 4;
            fireWarrior.Strength = 3;
            fireWarrior.Toughness = 3;
            fireWarrior.Wounds = 1;
            fireWarrior.Attack = 1;
            fireWarrior.Leadership = 6;
            fireWarrior.Save = 4;

            // Act
            bool hit = engine.Hit(guardsman, fireWarrior);

            // Assert
            Assert.IsTrue(hit);
        }

        [Test]
        public void Hit_False()
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(1);

            WbsEngine engine = new WbsEngine(dice);

            Unit guardsman = new Unit();
            guardsman.Name = "Guardsman";
            guardsman.Movement = 6;
            guardsman.WeaponSkill = 4;
            guardsman.BallisticSkill = 4;
            guardsman.Strength = 3;
            guardsman.Toughness = 3;
            guardsman.Wounds = 1;
            guardsman.Attack = 1;
            guardsman.Leadership = 6;
            guardsman.Save = 5;

            Unit fireWarrior = new Unit();
            fireWarrior.Name = "Fire Warrior";
            fireWarrior.Movement = 6;
            fireWarrior.WeaponSkill = 5;
            fireWarrior.BallisticSkill = 4;
            fireWarrior.Strength = 3;
            fireWarrior.Toughness = 3;
            fireWarrior.Wounds = 1;
            fireWarrior.Attack = 1;
            fireWarrior.Leadership = 6;
            fireWarrior.Save = 4;

            // Act
            bool hit = engine.Hit(guardsman, fireWarrior);

            // Assert
            Assert.IsFalse(hit);
        }
    }
}
