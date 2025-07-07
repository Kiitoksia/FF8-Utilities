using FF8Utilities.Models;
using FlowTimer;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FF8Utilities.Dialogs
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        private bool _initialised;
        private bool _playingBeeps;
        public SettingsWindow(SettingsModel settings)
        {
            InitializeComponent();
            DataContext = settings;
            Loaded += SettingsWindow_Loaded;
        }

        private SettingsModel Model => (SettingsModel)DataContext;

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _initialised = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PlayTestBeeps()
        {
            if (!_initialised || _playingBeeps) return;
            _playingBeeps = true;
            AudioContext audioContext;
            Stream waveStream;
            byte[] pcm;
            switch (Model.BeepSound)
            {
                case BeepSound.Ping1: waveStream = Properties.Resources.ping1; break;
                case BeepSound.Ping2: waveStream = Properties.Resources.ping2; break;
                case BeepSound.Click: waveStream = Properties.Resources.click1; break;
                case BeepSound.Clack: waveStream = Properties.Resources.clack; break;
                default: throw new ArgumentOutOfRangeException(nameof(SettingsModel.Instance.BeepSound), "Unknown beep sound setting");
            }
            using (waveStream)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    waveStream.CopyTo(memoryStream);
                    Wave.LoadWAV(memoryStream.ToArray(), out pcm, out SDL.SDL_AudioSpec spec);
                    audioContext = new AudioContext(spec.freq, spec.format, spec.channels);
                }
            }
            int interval = Model.BeepInterval;
            int desiredBeeps = Model.BeepCount;
            int playedBeeps = 0;
            // Play at normal speed
            Timer currentlyPlayingTimer = null;
            currentlyPlayingTimer = new Timer((state) =>
            {
                audioContext.QueueAudio(pcm);
                playedBeeps++;
                if (playedBeeps > desiredBeeps)
                {
                    currentlyPlayingTimer?.Dispose();
                    audioContext.Destroy();
                    _playingBeeps = false;
                    return;
                }
            }, null, 0, interval);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayTestBeeps();
        }

        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            PlayTestBeeps();
        }
    }
}
