using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;

namespace SADCL
{
    public abstract class MissileLauncher:ImissileCommand
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

        public abstract void command_Stop();
        public abstract void command_Right(int degrees);
        public abstract void command_Left(int degrees);
        public abstract void command_Up(int degrees);
        public abstract void command_Down(int degrees);
        public abstract void command_Fire();
        public abstract void reload();

        public abstract void command_switchLED(Boolean turnOn);
        public abstract void command_reset();
        public abstract void moveMissileLauncher(byte[] Data, int interval);
        public abstract void SendUSBData(byte[] Data);
        public abstract void USB_OnDataRecieved(object sender, DataRecievedEventArgs args);
        public abstract void USB_OnSpecifiedDeviceArrived(object sender, EventArgs e);
        public abstract void USB_OnSpecifiedDeviceRemoved(object sender, EventArgs e);
        public abstract int getMissles();
        public abstract void setMissles();
        public abstract string getName();
        public abstract void setName(string value);
    }
}

