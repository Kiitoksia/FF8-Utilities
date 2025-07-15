using CardManipulation;
using CardManipulation.Models;
using FF8Utilities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FF8Utilities.Test
{
    [TestClass]
    public class CardManipUnitTests
    {
        private const uint Frame4Quistis = 0x65c6be07;


        static CardManipUnitTests()
        {
            new SettingsModel(new MainModel());
        }


        [TestMethod]
        public void TestSecondTryMash()
        {
            CardManip manip = new CardManip();
            CardManipulationModel model = new CardManipulationModel(manip, Frame4Quistis, "zellmama", 9, null);
            model.RecoveryPattern = "74441154176425316556";
            model.GetInstantMashText();
            RareTimerResult result = model.GetFirstFrameResult();
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == model.FirstAvailableFrame);
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == 18);            
        }
    }
}
