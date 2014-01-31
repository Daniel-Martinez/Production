using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HelloWorld
{
    class Hello
    {
        
        static void Main(string[] args)
        {
            
            string line = "";
            // will store the file from StreamReader's argument in rfile
            System.IO.StreamReader rfile = null;//new System.IO.StreamReader(args[0]);
            //check to see if there is an argument
            if (args.Length > 0)
            {
                rfile = new System.IO.StreamReader(args[0]);
            }

            // will read a line of rfile and display it out to console until we reach the EOF(null)
            TextWriter wfile = new StreamWriter("C:/Users/Daniel/Desktop/SnD/date.txt");
            while ((line = rfile.ReadLine()) != null)
            {
                wfile.WriteLine(line);  
                Console.WriteLine(line);
            }
            wfile.Close();

            //close the file we just used
            rfile.Close();
            
        }
    }

}

