using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models
{
    public class DownloadModel
    {
        public DownloadModel(string title, IProgress<decimal> progress)
        {
            Title = title;
            Progress = progress;
        }

        public DownloadModel()
        {

        }

        public string Title { get; }

        public IProgress<decimal> Progress { get; }
    }
}
