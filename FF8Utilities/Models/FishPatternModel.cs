using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models
{
    public class FishPatternModel
    {
        public FishPatternModel(JObject json)
        {
            Index = json.Value<int>("index");
            Pattern = json.Value<string>("pattern");
            ATBRefreshes = json.Value<string>("atbrefresh");
            DropCount = json.Value<string>("findrop");
            Phase1Comment = json.Value<string>("phase1comment");
            Phase2Comment = json.Value<string>("phase2comment");
            Phase3Comment = json.Value<string>("phase3comment");
            GeneralComment = json.Value<string>("generalcomment");

            Phase1CommentsVisible = !string.IsNullOrWhiteSpace(Phase1Comment);
            Phase2CommentsVisible = !string.IsNullOrWhiteSpace(Phase2Comment);
            Phase3CommentsVisible = !string.IsNullOrWhiteSpace(Phase3Comment);
            GeneralCommentsVisible = !string.IsNullOrWhiteSpace(GeneralComment);
        }

        public int Index { get; private set; }
        public string Pattern { get; private set; }
        public string ATBRefreshes { get; private set; }
        public string DropCount { get; private set;  }
        public string Phase1Comment { get; private set; }
        public string Phase2Comment { get; private set; }
        public string Phase3Comment { get; private set; }
        public string GeneralComment { get; private set; }

        public bool Phase1CommentsVisible { get; private set; }
        public bool Phase2CommentsVisible { get; private set; }
        public bool Phase3CommentsVisible { get; private set; }
        public bool GeneralCommentsVisible { get; private set; }
    }
}
