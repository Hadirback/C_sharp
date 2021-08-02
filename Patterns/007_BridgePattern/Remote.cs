using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_BridgePattern
{
    public class Remote
    {
        protected IDevice device;

        public Remote(IDevice device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            if (device.IsEnabled())
                device.Disable();
            else
                device.Enable();
        }

        public void VolumeUp()
        {
            int vol = device.GetVolume();
            if (vol <= 10)
                device.SetVolume(++vol);
        }

        public void VolumeDown()
        {
            int vol = device.GetVolume();
            if (vol >= 0)
                device.SetVolume(--vol);
        }

        public void ChannelDown()
        {
            int ch = device.GetChannel();
            if (ch >= 0)
                device.SetChannel(++ch);
        }


        public void ChannelUp()
        {
            int ch = device.GetChannel();
            if (ch <= 30)
                device.SetChannel(--ch);
        }
    }
}
