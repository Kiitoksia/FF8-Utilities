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
            Reload();
        }


        public static DataManager Current
        {
            get
            {
                if (_current == null) _current = new DataManager();
                return _current;
            }
        }

        public AppSettings CurrentSettings { get; private set; }


        private string SettingsPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FF8-Utilities", Const.SettingsFile);

        public void Reload()
        {
            XElement xml = null;
            if (File.Exists(SettingsPath)) xml = XElement.Load(SettingsPath);
            CurrentSettings = new AppSettings(xml);
        }

        public void Save()
        {
            XElement xml = null;
            CurrentSettings.CopyTo(ref xml);
            xml.Save(SettingsPath);
        }

    }
}
