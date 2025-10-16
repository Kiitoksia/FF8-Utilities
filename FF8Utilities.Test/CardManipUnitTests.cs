using CardManipulation;
using CardManipulation.Models;
using FF8Utilities.Models;
using LateQuistisManipulation;
using LateQuistisManipulation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            System.Threading.Thread.Sleep(millisecondsToWait + 150);
            model.SubmitCommand.Execute(null);
        }

        [TestMethod]
        public void TestSecondTryMash()
        {
            CardManip manip = new CardManip();


            // Nonaru PB.  4th Quistis, Index 449
            CardManipulationModel model = new CardManipulationModel(manip, Frame4Quistis, "zellmama", 9, null);
            model.RecoveryPattern = "74441154176425316556";
            model.SubmitCommand.Execute(null);

            RareTimerResult result = model.GetFirstFrameResult();
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == model.FirstAvailableFrame, "First available frame doesnt match");
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == 101, "Invalid first available frame");         
            
            StartTimerAndWait(model, 1880); // Roughly 1.7s in
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0], "Should be an instant mash");

            // Habkeinename PB.  4th Quistis, Index 513

            model = new CardManipulationModel(manip, Frame4Quistis, "zellmama", 9, null);
            model.RecoveryPattern = "55324324465533456554";
            model.SubmitCommand.Execute(null);

            result = model.GetFirstFrameResult();
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == model.FirstAvailableFrame, "First available frame doesnt match");
            Assert.IsTrue(result.RareTable.FindIndex(t => t) == 109, "Invalid first available frame");

            StartTimerAndWait(model, 2000); // Roughly 2s in
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0], "Should be an instant mash");
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

        [TestMethod]
        public void TestLQFrames()
        {
            CardManip manip = new CardManip();
            LateQuistis lq = new LateQuistis(Const.PackagesFolder);
            for (int i = 130; i < 190; i++)
            {
                // Safe region
                LateQuistisPattern pattern = lq.GetPattern(i, false);
                string mashText = pattern.Deck.InstantMash;
                CardManipulationModel model = new CardManipulationModel(manip, 0, "fc01", 9, i);
                Match framesMatch = Regex.Match(mashText, @"(\d+)$");
                int firstFrame = int.Parse(framesMatch.Groups[1].Value);
                Assert.IsTrue(firstFrame == model.FirstAvailableFrame);
            }
        }

        [TestMethod]
        public void TestLQMashZell()
        {
            CardManip manip = new CardManip();
            CardManipulationModel model = new CardManipulationModel(manip, 0xa00ba819, "zellmama", 9, null);
            model.RecoveryPattern = "7274-7365-6762-5532-5637";
            model.SubmitCommand.Execute(null);
            Assert.IsTrue(model.ErrorText == null, "A recovery pattern should be found");
            RareTimerResult result = model.GetFirstFrameResult();
            Assert.IsTrue(!result.RareTable[0], "Invalid frame, is not instant mash");

            StartTimerAndWait(model, 220);
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0], "Did not find card");
        }

        public void TestChaining()
        {
            // TODO
            // Start on a a particular EQ/LQ index and get the zell card frame
            // Then recursively submit until middle of snake, and do recovery with the found cards
            // Repeat this 5 times, ensure zell card always appears

            CardManip manip = new CardManip();
            CardManipulationModel model = new CardManipulationModel(manip, 0xa00ba819, "zellmama", 9, null);


            model.RecoveryPattern = "7274-7365-6762-5532-5637";
            model.SubmitCommand.Execute(null);
            Assert.IsTrue(model.ErrorText == null, "A recovery pattern should be found");
            RareTimerResult result = model.GetFirstFrameResult();
            Assert.IsTrue(!result.RareTable[0], "Invalid frame, is not instant mash");


            StartTimerAndWait(model, 220);
            result = model.CurrentResult;
            Assert.IsTrue(result.RareTable[0], "Did not find card");
        }
    }
}
