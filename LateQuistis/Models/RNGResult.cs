using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class RNGResult
    {
        public RNGResult(string rngHex, int rngIndex, string frame1Result, string frame2Result, string frame3Result, string frame4Result, string frame5Result, string frame6Result, 
            string frame7Result, string frame8Result, string frame9Result, string frame10Result, string extraFrameResult)
        {
            RNGHex = rngHex;
            RNGIndex = rngIndex;
            Frame1Result = frame1Result;
            Frame2Result = frame2Result;
            Frame3Result = frame3Result;
            Frame4Result = frame4Result;
            Frame5Result = frame5Result;
            Frame6Result = frame6Result;
            Frame7Result = frame7Result;
            Frame8Result = frame8Result;
            Frame9Result = frame9Result;
            Frame10Result = frame10Result;
            ExtraFrameResult = extraFrameResult;
        }

        public string RNGHex { get; }

        public int RNGIndex { get; }

        public string Frame1Result { get; }
        public string Frame2Result { get; }
        public string Frame3Result { get; }
        public string Frame4Result { get; }
        public string Frame5Result { get; }
        public string Frame6Result { get; }
        public string Frame7Result { get; }
        public string Frame8Result { get; }
        public string Frame9Result { get; }
        public string Frame10Result { get; }
        public string ExtraFrameResult { get; }

        internal bool IsValid => !string.IsNullOrEmpty(string.Concat(Frame1Result, Frame2Result, Frame3Result, Frame4Result, Frame5Result, Frame6Result, 
            Frame7Result, Frame8Result, Frame9Result, Frame10Result, ExtraFrameResult).Replace("XX", string.Empty));
    }
}
