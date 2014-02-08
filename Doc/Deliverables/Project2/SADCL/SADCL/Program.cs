using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SADCL
{
    class Program
    {
        static void Main(string[] args)
        {

            missileCommand Poseidon = new missileCommand();  // missile launcher is created
            Poseidon.load = 4;  // fully loaded and ready to fire. 
            string input = "";  //user input
            while (input != "exit")
            {
                input = Console.ReadLine().ToLower();   // conver to lowercase
                switch (input)
                {
                    case "fire":
                        Poseidon.fire();
                        break;
                    case "reload":
                        Poseidon.reload();
                        break;
                    case "status":
                        Console.WriteLine("Launcher:  \n ");
                        Console.WriteLine("\tMissiles:  " + Poseidon.load + " of 4 remain");
                        break;
                    default:
                        break;
                }
            }









            int x = 2000;
            int y = 4000;
           // MissileLauncher test = new MissileLauncher();
           
        }
    }

}
