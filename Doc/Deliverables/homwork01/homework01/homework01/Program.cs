using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Homework1
{
    class hwk01
    {
        static void Main(string[] args)
        {
            // will store the file from StreamReader's argument in rfile
            string readfile = "";

            //check to see if there is an argument and if the specified path exist
            if (args.Length > 0)
            {
                readfile = args[0];
            }
            else
            {
                System.Console.WriteLine("What the Path? Please specify an input file\n");
                // used to handle error when there is no specified file path
            }
            /* changed to use readfile because StreamReader wasn't working and 
               it works with a string */
            if (!File.Exists(readfile))
            {
                System.Console.WriteLine("What the Path? You are on the wrong path.\n");
                return;
            }
            else
            {
                /* now we are ready to get the user commands */
                commandReader();
            }
        }

    }
}





