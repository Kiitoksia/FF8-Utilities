﻿using System;
using System.Xml.Linq;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    // Not technically in Ifrits Cavern, but combining it for simplicity
    public class FishFinsEncounter : BaseModel, IEncounter
    {
        private int _squallPhysicals;
        private int _limits = 2;
        private TwoPersonFanfareCamera? _camera;
        private bool _singleFishEmerged;

        public FishFinsEncounter()
        {

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

        public TwoPersonFanfareCamera? Camera
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
                switch (Camera)
                {
                    case null:
                        break;
                    case TwoPersonFanfareCamera.SingleCharacter:
                        output += 2;
                        break;
                    case TwoPersonFanfareCamera.TwoCharacters:
                        output += 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recongised");
                }

                return Base + output;
            }
        }


        public string Description => "Fish Fins";

        public int Base => 15;

        public XElement ToXml()
        {
            XElement xml = new XElement(nameof(FishFinsEncounter));
            xml.Add(new XAttribute(nameof(SquallPhysicals), SquallPhysicals));
            xml.Add(new XAttribute(nameof(Limits), Limits));
            xml.Add(new XAttribute(nameof(SingleFishKilled), SingleFishKilled));
            return xml;
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
