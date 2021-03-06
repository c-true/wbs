﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTrue.Wbs.Core.Test
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void Roll_GreaterThanZero()
        {
            Dice terning = new Dice();

            int verdi = terning.Roll();

            Assert.IsTrue(verdi > 0);
        }

        [TestMethod]
        public void Roll_LessThanSeven()
        {
            Dice terning = new Dice();

            int verdi = terning.Roll();

            Assert.IsTrue(verdi < 7);
        }

        //[TestMethod]
        //public void Roll_IsRandom()
        //{
        //    Dice terning = new Dice();

        //    int[] verdiliste = new int[3];
        //    verdiliste[0] = terning.Roll();
        //    verdiliste[1] = terning.Roll();
        //    verdiliste[2] = terning.Roll();

        //    Assert.IsTrue(verdiliste[0] != verdiliste[1] && verdiliste[0] != verdiliste[2]);
        //}
    }
}
