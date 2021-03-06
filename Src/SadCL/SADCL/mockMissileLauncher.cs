﻿using System;
using System.Threading;
using UsbLibrary;


namespace SADCL
{
    public class mockMissileLauncher:MissileLauncher, ImissileCommand
    {

        public int load //begin load function
        {
            get { return missiles; }
            set
            {
                missiles = value;
            }
        } //end load function
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public mockMissileLauncher()
        {

            this.UP = new byte[10];
            this.UP[1] = 2;
            this.UP[2] = 2;

            this.DOWN = new byte[10];
            this.DOWN[1] = 2;
            this.DOWN[2] = 1;

            this.LEFT = new byte[10];
            this.LEFT[1] = 2;
            this.LEFT[2] = 4;

            this.RIGHT = new byte[10];
            this.RIGHT[1] = 2;
            this.RIGHT[2] = 8;

            this.FIRE = new byte[10];
            this.FIRE[1] = 2;
            this.FIRE[2] = 0x10;

            this.STOP = new byte[10];
            this.STOP[1] = 2;
            this.STOP[2] = 0x20;

            this.LED_ON = new byte[9];
            this.LED_ON[1] = 3;
            this.LED_ON[2] = 1;

            this.LED_OFF = new byte[9];
            this.LED_OFF[1] = 3;

            this.USB = new UsbHidPort();
            this.USB.ProductId = 0;
            this.USB.SpecifiedDevice = null;
            this.USB.VendorId = 0;
            this.USB.OnSpecifiedDeviceRemoved += new EventHandler(this.USB_OnSpecifiedDeviceRemoved);
            this.USB.OnDataRecieved += new DataRecievedEventHandler(this.USB_OnDataRecieved);
            this.USB.OnSpecifiedDeviceArrived += new EventHandler(this.USB_OnSpecifiedDeviceArrived);


            this.USB.VID_List[0] = 0xa81;
            this.USB.PID_List[0] = 0x701;
            this.USB.VID_List[1] = 0x2123;
            this.USB.PID_List[1] = 0x1010;
            this.USB.ID_List_Cnt = 2;

            IntPtr handle = new IntPtr();
            this.USB.RegisterHandle(handle);
        }

        public override void command_Stop()
        {
            this.SendUSBData(this.STOP);
        }

        public override void command_Right(int degrees)
        {
            Console.Write("Moved to the right by " + degrees + " degrees Captain!\n");
            
            //degrees = degrees * 20;
            //this.moveMissileLauncher(this.RIGHT, degrees);
        }

        public override void command_Left(int degrees)
        {
            Console.Write("Moved to the left by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moveMissileLauncher(this.LEFT, degrees);
        }

        public override void command_Up(int degrees)
        {
            Console.Write("Moved up angle by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moveMissileLauncher(this.UP, degrees);
        }

        public override void command_Down(int degrees)
        {
            Console.Write("Moved down angle by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moveMissileLauncher(this.DOWN, degrees);
        }

        public override void command_Fire()
        {
            
            if (missiles <= 0)
            {
                Console.WriteLine("I just can't do it cap'tin, we just don't have the power.\n");
            }
            else
            {
                Console.WriteLine("Ka-BOOM\n");
            }

            missiles--;  // decrease the missiles available
        }
        public override void reload()
        {
            missiles = 4;
        }

        public override int getMissles()
        {
            return missiles;

        }
        public override void setMissles()
        {
            missiles = 4;

        }
        public override string getName()
        {
            return name;
        }
        public override void setName(string value)
        {
            name = value;
        }
        public override void command_switchLED(Boolean turnOn)
        {
            if (DevicePresent)
            {
                if (turnOn)
                {
                    this.SendUSBData(this.LED_ON);
                }
                else
                {
                    this.SendUSBData(this.LED_OFF);
                }
                this.SendUSBData(this.STOP);
            }
        }


        public override void command_reset()
        {
            if (DevicePresent)
            {
                this.moveMissileLauncher(this.LEFT, 5500);
                this.moveMissileLauncher(this.RIGHT, 2950);  //2750 originally
                this.moveMissileLauncher(this.UP, 2000);
                this.moveMissileLauncher(this.DOWN, 500);
            }
        }

        public override void moveMissileLauncher(byte[] Data, int interval)
        {
            if (DevicePresent)
            {

                this.command_switchLED(true);
                this.SendUSBData(Data);
                Thread.Sleep(interval);
                this.SendUSBData(this.STOP);
                this.command_switchLED(false);
            }
        }

        public override void SendUSBData(byte[] Data)
        {
            if (this.USB.SpecifiedDevice != null)
            {
                this.USB.SpecifiedDevice.SendData(Data);
            }
        }


        public override void USB_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {

        }

        public override void USB_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.DevicePresent = true;
            if (this.USB.ProductId == 0x1010)
            {
                this.command_switchLED(true);
            }
        }

        public override void USB_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            this.DevicePresent = false;
        }

    }

}
