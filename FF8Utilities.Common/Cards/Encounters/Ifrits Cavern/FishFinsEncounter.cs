using System;
using System.Windows.Input;
using System.Xml.Linq;

namespace FF8Utilities.Common.Cards.Encounters.IfritsCavern
{
    // Not technically in Ifrits Cavern, but combining it for simplicity
    public class FishFinsEncounter : BaseModel, IEncounter
    {
        private int _squallPhysicals;
        private int _limits = 2;
        private FanfareCamera _camera = FanfareCamera.TwoPerson.None;
        private bool _singleFishEmerged;
        private bool _isPickerOpen;

        public FishFinsEncounter()
        {
            OpenPickerCommand = new RelayCommand(() => IsPickerOpen = true);
        }

        public int SquallPhysicals
        {
            get => _squallPhysicals;
            set
            {
                if (value == _squallPhysicals) return;
                _squallPhysicals = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Limits
        {
            get => _limits;
            set
            {
                if (value == _limits) return;
                _limits = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public FanfareCamera Camera
        {
            get => _camera;
            set
            {
                if (value == _camera) return;
                _camera = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public bool SingleFishKilled
        { 
            get => _singleFishEmerged; 
            set
            { 
                if (value == _singleFishEmerged) return;
                _singleFishEmerged = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }


        public int RngAddition
        {
            get
            {
                int output = SquallPhysicals * 2;
                output += Limits;
                output += SingleFishKilled ? 11 : 22; // Fish fins floating up after being hit
                output += Camera?.RngAddition ?? 0;               

                return Base + output;
            }
        }


        public string Description => "Fish Fins";

        public int Base => 15;

        public XElement ToXml()
        {
            XElement xml = new XElement(nameof(IfritsCavern.FishFinsEncounter));
            xml.Add(new XAttribute(nameof(SquallPhysicals), SquallPhysicals));
            xml.Add(new XAttribute(nameof(Limits), Limits));
            xml.Add(new XAttribute(nameof(SingleFishKilled), SingleFishKilled));
            return xml;
        }

        /// <summary>
        /// Only used by MAUI to open the picker, PC has it in-line
        /// </summary>
        public ICommand OpenPickerCommand { get; set; }

        public bool IsPickerOpen 
        { 
            get => _isPickerOpen; 
            set 
            {
                if (value == _isPickerOpen) return;
                _isPickerOpen = value;
                OnPropertyChanged();
            } 
        }

        public void FromXml(XElement xml)
        {
            if (int.TryParse(xml.Attribute(nameof(SquallPhysicals))?.Value ?? string.Empty, out int squallPhysicals))
            {
                SquallPhysicals = squallPhysicals;
            }

            if (int.TryParse(xml.Attribute(nameof(Limits))?.Value ?? string.Empty, out int limits))
            {
                Limits = limits;
            }

            if (bool.TryParse(xml.Attribute(nameof(SingleFishKilled))?.Value ?? string.Empty, out bool singleFin))
            {
                SingleFishKilled = singleFin;
            }
        }
    }
}
