using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;

namespace CTrue.Wbs.Core.Test
{
   [TestClass]
    public class WbsEngineTest
    {
        [TestMethod]
        public void Hit_DicerollHigerThenBalisticskillThenTrue()
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(5);

            WbsEngine engine = new WbsEngine(dice) ;

            Unit guardsman = Createguardsman();  
            Unit fireWarrior = Createfirewarrior();
           
            // Act
            bool hit = engine.Hit(guardsman, fireWarrior);

            // Assert
            Assert.IsTrue(hit);
        }

        [TestMethod]
        public void Hit_False()
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(1);

            WbsEngine engine = new WbsEngine(dice);

            Unit guardsman = Createguardsman();
            Unit fireWarrior = Createfirewarrior();
           
            // Act
            bool hit = engine.Hit(guardsman, fireWarrior);

            // Assert
            Assert.IsFalse(hit);
        }

        private Unit Createguardsman()
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
        private Unit Createfirewarrior()
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
        
    }
}
