using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FF8Utilities.Data
{
    public class DataManager
    {
        private static DataManager _current;


        public DataManager()
        {
            
        }


        public static DataManager Current
        {
            get
            {
                if (_current == null) _current = new DataManager();
                return _current;
            }
        }


        public bool IsFirstLaunch { get; private set; }
    }
}
