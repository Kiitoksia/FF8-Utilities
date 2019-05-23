﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Data
{
    public enum Platform
    {
        [Description("PS2 (NA)")]
        PS2,
        [Description("PS2 (JP)")]
        PS2JP,
        PC
    }

    public static class Const
    {
        public const string SettingsFile = "Settings";
    }
}
