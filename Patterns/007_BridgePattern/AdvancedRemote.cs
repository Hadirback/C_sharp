using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_BridgePattern
{
    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device)
            : base(device) { }

        public void Mute()
        {
            device.SetVolume(0);
        }
    }
}
