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

        private void StartTimerAndWait(CardManipulationModel model, int millisecondsToWait)
        {
            model.SubmitCommand.Execute(null);
            System.Threading.Thread.Sleep(millisecondsToWait);
            model.SubmitCommand.Execute(null);
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

        [TestMethod]
        public void TestLQ130Frame4Zell241()
        {
            CardManip manip = new CardManip();
            CardManipulationModel model = new CardManipulationModel(manip, 0x9725c716, "zellmama", 9, 241);
            StartTimerAndWait(model, 750); // Wait 750ms, this is roughly middle of snake
            
            // Index is actually 239, run recovery pattern
            model.RecoveryPattern = "26123345763154335311";
            model.SubmitCommand.Execute(null);
            model.GetInstantMashText();
            RareTimerResult result = model.GetFirstFrameResult();

            // Backup should be 2.2s in
            StartTimerAndWait(model, 2200);
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0]);
        }
    }
}
