using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    class missileCommand: MissileLauncher
    {
        private string name = ""; 
        private int missiles;   // used to keep track of missiles in the chamber
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
                name = "Poseidon";
            }
        }
        public void fire() // begin fire function
        {
            if (missiles <= 0)
            {
                Console.WriteLine("I just can't do it cap'tin, we just don't have the power.");
            }
            else
            {
                command_Fire();
            }
            missiles--;  // decrease the missiles available
            
        } //end fire function

        public void reload() // begin reload function
        {
            missiles = 4; 
        }

        public void moveRight(int degrees) 
        {
            degrees = degrees * 20;
            command_Right(degrees);
        }
        public void moveLeft(int degrees) 
        {
            degrees = degrees * 20;
            command_Left(degrees);
        }
        public void moveUp(int degrees)
        {
            degrees = degrees * 20;
           command_Up(degrees);
        }

        internal void moveDown(int degrees)
        {
            degrees = degrees * 20;
            command_Down(degrees);
        }

        internal void calibrate()
        {
            command_reset();
        }
    }

}
