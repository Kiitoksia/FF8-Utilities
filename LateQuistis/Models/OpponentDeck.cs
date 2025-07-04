﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class OpponentDeck
    {
        public OpponentDeck(string rngHex, int rngIndex, string instantMash, string frame1, string frame2, string frame3, string frame4, string frame5, 
            string frame6, string frame7, string frame8, string frame9, string frame10, string extraFrame)
        {
            RNGHex = rngHex;
            RNGIndex = rngIndex;
            InstantMash = instantMash;
            Frame1 = frame1;
            Frame2 = frame2;
            Frame3 = frame3;
            Frame4 = frame4;
            Frame5 = frame5;
            Frame6 = frame6;
            Frame7 = frame7;
            Frame8 = frame8;
            Frame9 = frame9;
            Frame10 = frame10;
            ExtraFrame = extraFrame;
        }

        public string RNGHex { get; }

        public int RNGIndex { get; }
        public string InstantMash { get; }

        public string Frame1 { get; }
        public string Frame2 { get; }
        public string Frame3 { get; }
        public string Frame4 { get; }
        public string Frame5 { get; }
        public string Frame6 { get; }
        public string Frame7 { get; }
        public string Frame8 { get; }
        public string Frame9 { get; }
        public string Frame10 { get; }

        public string ExtraFrame { get; set; }

        internal bool IsValid => !string.IsNullOrEmpty(string.Concat(Frame1,Frame2, Frame3, Frame4, Frame5, Frame6, Frame7, Frame8, Frame9, Frame10).Trim());

        public string GetFrame(int frame)
        {
            switch (frame)
            {
                case 1: return Frame1;
                case 2: return Frame2;
                case 3: return Frame3;
                case 4: return Frame4;
                case 5: return Frame5;
                case 6: return Frame6;                        
                case 7: return Frame7;
                case 8: return Frame8;                        
                case 9: return Frame9;
                case 10: return Frame10;
                case 11: return ExtraFrame;
                default: throw new NotImplementedException();                        
            }
        }
    }
}
