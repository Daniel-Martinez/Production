using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;

namespace SADCL
{
    public interface ImissileCommand
    {
        void command_Stop();
        void command_Right(int degrees);
        void command_Left(int degrees);
        void command_Up(int degrees);
        void command_Down(int degrees);
        void command_Fire();
        void command_switchLED(Boolean turnOn);
        void command_reset();
        void reload();
       
    }
}
