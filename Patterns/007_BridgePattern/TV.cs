using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_BridgePattern
{
    public class TV: IDevice
    {
        private int channel = 0;
        private bool isEnabled = false;
        private int volume = 5;

        public TV()
        {

        }

        public TV(int channel, bool isEnabled, int volume)
        {
            this.channel = channel;
            this.isEnabled = isEnabled;
            this.volume = volume;
        }

        public void Disable()
        {
            isEnabled = false;
            Console.WriteLine("Выключили Телевизор");
        }

        public void Enable()
        {
            isEnabled = true;
            Console.WriteLine("Включили Телевизор");
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
