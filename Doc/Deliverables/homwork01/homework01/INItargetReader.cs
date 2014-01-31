using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
public class INItargetReader
{
    string header = "";     // this pertains to the [Target]
    string name = "";       // this identifies name of target
    double x = 0;           // x cordinate
    double y = 0;           // y cordinate
    double z = 0;           // z cordinate
    bool friend = false;    // determines if a target is friend or foe
    double points = 0;      // used to keep track of what target is valued
    int flashRate = 0;      // idicates how long the target is visible
    public void INITargetReader.Parse(file rfile)
    {
        string line = "";
        ArrayList myArray = new ArrayList();
        
        while (line != null)
        {
            line = rfile.Console.ReadLine();
            if (line != null)
            {
                int i = 0;
                for (i; i <= 7; i++)
                {
                    myArray.Add(line);
                    i++;
                    line = rfile.ReadLine();
                }
                i = 0;
                // at this point we need to strip off after '=' 
                // we need to creat an object of our class type to use setters 
            }
        }
    }
    void set(string n, double xcor, double ycor, double zcor, bool target, double p, int f)
    {
        name = n;
        x = xcor;
        y = ycor;
        z = zcor;
        friend = target;
        points = p;
        flashRate = f;
    }
}

