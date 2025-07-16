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
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == model.FirstAvailableFrame, "First available frame doesnt match");
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == 18, "Invalid first available frame");            
        }

        [TestMethod]
        public void TestLQ130Frame4Zell241()
        {
            CardManip manip = new CardManip();
            CardManipulationModel model = new CardManipulationModel(manip, 0x9725c716, "zellmama", 9, 241);
            StartTimerAndWait(model, 750); // Wait 750ms, this is roughly middle of snake
            
            // Index is actually 238, run recovery pattern
            model.RecoveryPattern = "26123345763154335311";
            model.SubmitCommand.Execute(null);
            Assert.IsTrue(model.ErrorText == null, "A recovery pattern should be found");
            RareTimerResult result = model.GetFirstFrameResult();
            Assert.IsTrue(!result.RareTable[0], "Invalid frame, is not instant mash");

            // Backup should be 2.2s in
            StartTimerAndWait(model, 2200);
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0], "Did not find card");
        }

        public void TestLQFrames()
        {
            CardManip manip = new CardManip();
            // TODO, compare our own manip calculations to the pre-computed calculations in Kaivels LQ
        }
    }
}
