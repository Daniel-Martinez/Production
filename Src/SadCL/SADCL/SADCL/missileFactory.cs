using SADCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    //public enum launcher{mock, real}
    //{
        
    //}
    class missileFactory
    {
        
        public MissileLauncher product()
        {
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
