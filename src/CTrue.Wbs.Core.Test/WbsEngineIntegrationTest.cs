using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTrue.Wbs.Core.Test
{
    [TestClass]
    public class WbsEngineIntegrationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            WbsEngine engine = new WbsEngine();

            Unit guardsman = UnitFactory.Createguardsman();
            Weapon lasgun = UnitFactory.Createlasgun();
            Unit fireWarrior = UnitFactory.Createfirewarrior();

            // Act
            double killRatio = engine.DoBattle(guardsman, lasgun, fireWarrior, 10000);
            killRatio = killRatio * 100;

            // Assert
            //Assert.IsTrue(killRatio > 0.5 && killRatio <0.51);
            Console.WriteLine($"Kill ratio in percent: {killRatio}");
        }
    }

}

