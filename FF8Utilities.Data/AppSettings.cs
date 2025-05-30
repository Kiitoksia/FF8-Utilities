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

        public bool ZellTrackToDiablos { get; set; } = false;
        public bool GlobalHotkeys { get; set; } = false;
        public int? CustomZellDelayFrame { get; set; }
        public int ZellCountdownTimer { get; set; } = 3;

        public CSRLanguage CSRLanguage { get; set; } = CSRLanguage.English;


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
                if (platformNode.Value == "BadPort") platformNode.Value = "PC";
                if (Enum.TryParse(platformNode.Value, out Platform platform)) Platform = platform;
            }

            XElement zellTrackToDiablos = xml?.Element(nameof(ZellTrackToDiablos));

            if (zellTrackToDiablos != null)
            {
                if (bool.TryParse(zellTrackToDiablos.Value, out bool zellTrack)) ZellTrackToDiablos = zellTrack;
            }

            XElement globalHotkeysXml = xml?.Element(nameof(GlobalHotkeys));
            if (globalHotkeysXml != null)
            {
                if (bool.TryParse(globalHotkeysXml.Value, out bool globalHotkeys)) GlobalHotkeys = globalHotkeys;
            }

            GlobalHotkeys = false; // This is not great at the moment, force disable

            XElement customZellDelayFrameXml = xml?.Element(nameof(CustomZellDelayFrame));
            if (customZellDelayFrameXml != null)
            {
                if (int.TryParse(customZellDelayFrameXml.Value, out int frames)) CustomZellDelayFrame = frames;
            }

            XElement zellCountdownTimerXml = xml?.Element(nameof(ZellCountdownTimer));
            if (zellCountdownTimerXml != null)
            {
                if (int.TryParse(zellCountdownTimerXml.Value, out int timer)) ZellCountdownTimer = timer;
            }

            XElement csrLanguageXml = xml?.Element(nameof(CSRLanguage));
            if (csrLanguageXml != null)
            {
                if (Enum.TryParse(csrLanguageXml.Value, out CSRLanguage csrLanguage)) CSRLanguage = csrLanguage;
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

            XElement zellTrackingNode = xml.Element(nameof(ZellTrackToDiablos));
            if (zellTrackingNode == null)
            {
                zellTrackingNode = new XElement(nameof(ZellTrackToDiablos));
                rootNode.Add(zellTrackingNode);
            }

            zellTrackingNode.Value = ZellTrackToDiablos.ToString();

            XElement globalHotkeys = xml.Element(nameof(GlobalHotkeys));
            if (globalHotkeys == null)
            {
                globalHotkeys = new XElement(nameof(GlobalHotkeys));
                rootNode.Add(globalHotkeys);
            }

            XElement customZellDelayFrames = xml.Element(nameof(CustomZellDelayFrame));
            if (customZellDelayFrames == null)
            {
                customZellDelayFrames = new XElement(nameof(CustomZellDelayFrame));
                rootNode.Add(customZellDelayFrames);
            }

            
            customZellDelayFrames.Value = CustomZellDelayFrame?.ToString() ?? string.Empty;

            XElement zellCountdownTimer = xml.Element(nameof(ZellCountdownTimer));
            if (zellCountdownTimer == null)
            {
                zellCountdownTimer = new XElement(nameof(ZellCountdownTimer));
                rootNode.Add(zellCountdownTimer);
            }

            zellCountdownTimer.Value = ZellCountdownTimer.ToString();

            XElement csrLanguage = xml.Element(nameof(CSRLanguage));
            if (csrLanguage == null)
            {
                csrLanguage = new XElement(nameof(csrLanguage));
                rootNode.Add(csrLanguage);
            }

            csrLanguage.Value = CSRLanguage.ToString();

            return xml;
        }
    }
}
