using SADCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{

    class missileFactory
    {
        
        public MissileLauncher product()
        {
            Console.WriteLine("Would you like the real deal Hollifield or just a Mock\n\n\tPress M for a mock turret \n\tPress R for a real turret");
            string input = Console.ReadLine().ToLower(); 
            if (input == "m")
            {
                MissileLauncher temp = new mockMissileLauncher();
                return temp;
            }
            else if (input == "r")
            {
                MissileLauncher temp = new missileLauncher();
                return temp;
            }           
            else
            {
               return null;
            }
        }
    }
}
