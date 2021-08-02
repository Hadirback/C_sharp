using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_BridgePattern
{
    public class Radio : IDevice
    {
        private int channel = 0;
        private bool isEnabled = false;
        private int volume = 5;

        public Radio()
        {

        }

        public Radio(int channel, bool isEnabled, int volume)
        {
            this.channel = channel;
            this.isEnabled = isEnabled;
            this.volume = volume;
        }
        public void Disable()
        {
            isEnabled = false;
            Console.WriteLine("Выключили радио");
        }

        public void Enable()
        {
            isEnabled = true;
            Console.WriteLine("Включили радио");
        }

        public int GetChannel()
        {
            return channel;
        }

        public int GetVolume()
        {
            return volume;
        }

        public bool IsEnabled()
        {
            return isEnabled;
        }

        public void SetChannel(int channel)
        {
            this.channel = channel;
        }

        public void SetVolume(int percent)
        {
            this.volume = percent;
        }
    }
}
