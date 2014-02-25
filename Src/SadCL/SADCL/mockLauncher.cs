using System;
using System.Threading;
using UsbLibrary;


namespace SADCL
{
    public class mockLauncher: ImissileCommand

    {
        public mockLauncher()
        {


        }
        
        public  void command_Right(int degrees)
        {
            Console.Write("Moved to the right by " + degrees + " degrees Captain!\n");
            
            //degrees = degrees * 20;
            //this.moverealLauncher(this.RIGHT, degrees);
        }

        public  void command_Left(int degrees)
        {
            Console.Write("Moved to the left by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moverealLauncher(this.LEFT, degrees);
        }

        public  void command_Up(int degrees)
        {
            Console.Write("Moved up angle by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moverealLauncher(this.UP, degrees);
        }

        public  void command_Down(int degrees)
        {
            Console.Write("Moved down angle by " + degrees + " degrees Captain!\n");
            //degrees = degrees * 20;
            //this.moverealLauncher(this.DOWN, degrees);
        }

        public  void command_Fire()
        {

                Console.WriteLine("Ka-BOOM\n");
    
        }
        public void reload(){}
        public string getName() { return null; }
        public void setName(string value){}
        public int getMissles() { return 0; }
        public void command_reset() { }


    }

}
