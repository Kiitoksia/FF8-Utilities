using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FF8Utilities.Data
{
    public class AppSettings
    {
        public bool AutoLaunchUltimecia { get; set; } = true;
        public Platform Platform { get; set; } = Platform.PS2;


        public AppSettings()
        {

        }

        /// <summary>
        /// Attempts to initialise values from XML
        /// </summary>
        public AppSettings(XElement xml)
        {
            XElement ultimeciaNode = xml?.Element(nameof(AutoLaunchUltimecia));

            if (ultimeciaNode != null)
            {
                if (bool.TryParse(ultimeciaNode.Value, out bool autoLaunch)) AutoLaunchUltimecia = autoLaunch;
            }

            XElement platformNode = xml?.Element(nameof(Platform));

            if (platformNode != null)
            {
                if (Enum.TryParse(platformNode.Value, out Platform platform)) Platform = platform;
            }
        }

        public XElement CopyTo(ref XElement xml)
        {
            XElement rootNode = xml?.Element("Settings");
            if (rootNode == null)
            {
                rootNode = new XElement("Settings");
                xml = rootNode;
            }

            XElement ultimeciaNode = xml.Element(nameof(AutoLaunchUltimecia));
            if (ultimeciaNode == null)
            {
                ultimeciaNode = new XElement(nameof(AutoLaunchUltimecia));
                rootNode.Add(ultimeciaNode);
            }

            ultimeciaNode.Value = AutoLaunchUltimecia.ToString();

            XElement platformNode = xml.Element(nameof(Platform));
            if (platformNode == null)
            {
                platformNode = new XElement(nameof(Platform));
                rootNode.Add(platformNode);
            }

            platformNode.Value = Platform.ToString();

            return xml;
        }
    }
}
