using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;

namespace SADCL
{
    public abstract class missileLauncher
    {
        public bool DevicePresent;
        public string name = "";
        public int missiles = 0;
        public byte[] UP;
        public byte[] RIGHT;
        public byte[] LEFT;
        public byte[] DOWN;

        public byte[] FIRE;
        public byte[] STOP;
        public byte[] LED_OFF;
        public byte[] LED_ON;

        public UsbHidPort USB;
        
    }
}

