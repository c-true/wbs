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
        [DataRow(5, true)]
        [DataRow(1, false)]
        [DataRow(2, false)]
        public void Hit_Test(int diceRoll, bool result)
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(diceRoll);

            WbsEngine engine = new WbsEngine(dice);

            Unit guardsman = Createguardsman();
            Unit fireWarrior = Createfirewarrior();

            // Act
            bool hit = engine.Hit(guardsman, fireWarrior);

            // Assert
            Assert.AreEqual(hit, result); 
        }
        

        [TestMethod]
        public void WoundRoll()
        {
            // Arrange 
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(1);

            WbsEngine engine = new WbsEngine(dice);

            Weapon lasgun = Createlasgun();
            Unit fireWarrior = Createfirewarrior();

            // Act
            bool wound = engine.Wound(lasgun, fireWarrior);

            // Assert
            Assert.IsFalse(wound);
        }

        [TestMethod]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(5, true)]
        public void SavingThrow_Fail(int diceRoll, bool result)
        {
            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).Returns(diceRoll);

            WbsEngine engine = new WbsEngine(dice);

            Weapon lasgun = Createlasgun();
            Unit fireWarrior = Createfirewarrior();

            // Act
            bool save = engine.Save(lasgun, fireWarrior);

            // Assert
            Assert.AreEqual(save, result);
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
        
        private Weapon Createlasgun()
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
