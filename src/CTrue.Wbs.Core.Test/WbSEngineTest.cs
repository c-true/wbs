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

            Unit guardsman = UnitFactory.Createguardsman();
            Unit fireWarrior = UnitFactory.Createfirewarrior();

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

            Weapon lasgun = UnitFactory.Createlasgun();
            Unit fireWarrior = UnitFactory.Createfirewarrior();

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

            Weapon lasgun = UnitFactory.Createlasgun();
            Unit fireWarrior = UnitFactory.Createfirewarrior();

            // Act
            bool save = engine.WasSaved(lasgun, fireWarrior);

            // Assert
            Assert.AreEqual(save, result);
        }

        [TestMethod]
        [DataRow(6,6,1, true)]
        [DataRow(1,6,1, false)]
        [DataRow(6,1,1, false)]
        [DataRow(6,6,6, false)]
        [DataRow(6,6,2, true)]

        public void Defender_Killed(int hitRoll, int woundRoll, int saveRoll, bool result)
        {
            // Arrange

            IDice dice = A.Fake<IDice>();
            A.CallTo(() => dice.Roll()).ReturnsNextFromSequence(hitRoll, woundRoll, saveRoll);

            WbsEngine engine = new WbsEngine(dice);

            Unit guardsman = UnitFactory.Createguardsman();
            Weapon lasgun = UnitFactory.Createlasgun();
            Unit fireWarrior = UnitFactory.Createfirewarrior();

            // Act
            bool DefenderKilled = engine.WasDefenderKilled(guardsman, lasgun, fireWarrior);

            // Assert
            Assert.AreEqual(result, DefenderKilled);
        }
    }
}
