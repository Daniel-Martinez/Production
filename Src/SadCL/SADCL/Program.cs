using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SADCL
{
    class program
    {
        static void Main(string[] args)
        {
            string path = "";

            if (args.Length > 0)    //testing command line entry.  If not valid thrown an error here.
            {
                path = args[0];     //path is now the variable that hold the command line argumnet
            }
            else
            {

                System.Console.WriteLine("Que Queres? I need path to input file!\n");    //outputs that the arugment is invalid.
                Thread.Sleep(5000);
                return;

            }

            //If the file path is invalid mesasge is displayed to the Caller.

            if (!File.Exists(path))
            {
                System.Console.WriteLine("no file to open at the path specified.\n");
                Thread.Sleep(5000);
                return;

            }
            else
            {
                /********************************************************************************************************************************************************************/
                //This body of the code defines our variables and creates the objects that we need to operate the ConmadLine Missle Launcher.
                /********************************************************************************************************************************************************************/

                List<target> targetList = targetFactory.Product(path);    //object targetList is a product of Factory containing all Target data read in from file

                singletonTargetManager tempObj = singletonTargetManager.getInstance();              //creating a singlton object to keep track of out target list with status of whos dead and whos at large
                List<target> statusList = tempObj.getList();

                statusList = targetList;                                  //set our singleton List equal to list generated from our target factory.

                missileFactory makeLauncher = new missileFactory();      // missile launcher is created


                MissileLauncherType test;                               //missle launcher type object
                ImissileCommand Poseidon;                               //object type to keep in scope
        
                Console.Write("Type the folling to create launcher\n\tR for real\n\tM for mock\n\n");  //what type of launcher do you want?

                string type = Console.ReadLine().ToLower();
                if (type == "r")
                {
                   test = MissileLauncherType.realLauncher;
                   Poseidon = makeLauncher.create(test);
                 
                }
                else if (type == "m")
                {
                   test = MissileLauncherType.mockLauncher;
                   Poseidon = makeLauncher.create(test);
                   
                }
                else
                {
                    return;
                }


                Poseidon.setName("Beef_Cake");            // name turret      
                Poseidon.reload();                        // fully loaded and ready to fire. 

                string input = "";
                string convInput = "";                           //Holds value for string when Split
                string enteredValue = "";                        //Holds user entered value for menu
                string enteredValue2 = "";                       //Holds user entered value for menu
                double phi = 0;
                double theta = 0;


                /********************************************************************************************************************************************************************/
                //This body of the code is our Commands section based on users input
                /********************************************************************************************************************************************************************/
                
                while (input != "exit")
                {
                                              //start off with full ammo
                    input = Console.ReadLine().ToLower();       // conver to lowercase
                    convInput = input.Split(' ')[0];            //user input is split on space for commands that require second text field 

                    if (input.Split(' ').Length > 1)            //if the result of Split results in a value then its assigned to givenTarget variable, 
                    {
                        enteredValue = input.Split(' ')[1];     //i.e this will be target's name, File name, or Phi value.
                    }
                    else
                    {
                        enteredValue = "";                      //if no value it will remain blank.
                    }
                    if (input.Split(' ').Length > 2)
                    {
                        enteredValue2 = input.Split(' ')[2];    //This will be used for Theta value for move and moveby methods
                    }
                    else
                    {
                        enteredValue2 = "";
                    }



                    switch (convInput)
                    {

                        case "fire":
                            Poseidon.command_Fire();
                            break;

                        case "move":
                            double mPhi = 0;
                            double mTheta = 0;
                                                                     //create a value to store our phi, which is x,y left/right
                            mPhi = Convert.ToDouble(enteredValue);   //converts entered value to a double

                            int temp = Convert.ToInt32(mPhi);        //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS
                            if (mPhi <= phi)                         //if entered value is less that zero it is a negative number and will move left.
                            {
                                double left = phi - mPhi;
                                int positive = Convert.ToInt32(left);
                                positive = Math.Abs(positive);      //must take absolute value of number to enter into moveLeft function
                                Poseidon.command_Left(positive);    //missle launcher moves left by amount entered
                                phi = phi - positive;
                            }
                            else
                            {
                                double right = mPhi - phi;
                                int positive = Convert.ToInt32(right);
                                positive = Math.Abs(positive);      //must take absolute value of number to enter into moveLeft function
                                Poseidon.command_Right(positive);       //if entered value is positive then we move right by amount entered
                                phi = phi + positive;
                            }
                            /* check to make sure values are entered */
                            //create a value to store our theta, which is Z up/down
                            //mTheta = Convert.ToDouble(enteredValue2);
                            int temp2 = Convert.ToInt32(mTheta);     //simalar to above

                            if (mTheta <= theta)
                            {
                                temp2 = Convert.ToInt32(theta - mTheta);
                                int positive = Math.Abs(temp2);
                                Poseidon.command_Down(positive);
                                theta = theta - positive;
                            }
                            else
                            {
                                temp2 = Convert.ToInt32(mTheta - theta);
                                int positive = Math.Abs(temp2);
                                Poseidon.command_Up(positive);
                                theta = theta + positive;
                            }
                            break;

                        case "moveby":
                            //phi = 0;                                //create a value to store our phi, which is x,y left/right
                            mPhi = Convert.ToDouble(enteredValue);   //converts entered value to a double
                            temp = Convert.ToInt32(mPhi);            //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS
                            if (mPhi <= 0)                            //if entered value is less that zero it is a negative number and will move left.
                            {
                                int positive = Math.Abs(temp);      //must take absolute value of number to enter into moveLeft function
                                Poseidon.command_Left(positive);    //missle launcher moves left by amount entered
                                phi = phi - positive;
                            }
                            else
                            {
                                Poseidon.command_Right(temp);       //if entered value is positive then we move right by amount entered
                                phi = phi + temp;
                            }

                            theta = 0;                              //create a value to store our theta, which is Z up/down
                            theta = Convert.ToDouble(enteredValue2);
                            temp2 = Convert.ToInt32(theta);         //simalar to above
                            if (theta < 0)
                            {
                                int positive = Math.Abs(temp2);
                                Poseidon.command_Down(positive);
                            }
                            else
                            {
                                Poseidon.command_Up(temp2);
                            }
                            break;


                        case "reload":                              //resets the missle launchers count to 4
                            Poseidon.reload();
                            break;

                        case "load":                                //lets user select another list of targets to load into game
                            path = enteredValue;

                            if (!File.Exists(path))
                            {
                                System.Console.WriteLine("yeh thats just a bad file.\n");
                            }
                            else
                            {
                                targetList = targetFactory.Product(path);
                                statusList = targetList;
                                Console.Write("argghh argghh new targets in sight!!\n\n");
                            }
                            break;
                        
                        case "scoundrels":

                            for (int i = 0; i < targetList.Count; i++)
                            {
                                if (targetList[i].isFriend != true)     //if not a freind print from target list.
                                {
                                    Console.Write("Target: " + targetList[i].Name + "\n");
                                    Console.Write("Friend: No He's a scoundrel with a clever disguise\n");
                                    Console.Write("Position: " + " x=" + targetList[i].X + ", y=" + targetList[i].Y + ", z=" + targetList[i].Z + "\n");
                                    Console.Write("Points: " + targetList[i].score + "\n");
                                    Console.Write("Status: " + targetList[i].Status + "\n");
                                    Console.Write("\n");
                                }

                            }
                            break;

                        case "friends":

                            for (int i = 0; i < targetList.Count; i++)
                            {
                                if (targetList[i].isFriend == true)     //if value for out Target isFriend is true he's cool
                                {
                                    Console.Write("Target: " + targetList[i].Name + "\n");
                                    Console.Write("Friend: One of us\n");
                                    Console.Write("Position: " + " x=" + targetList[i].X + ", y=" + targetList[i].Y + ", z=" + targetList[i].Z + "\n");
                                    Console.Write("Points: " + targetList[i].score + "\n");
                                    Console.Write("Status: " + targetList[i].Status + "\n");
                                    Console.Write("\n");
                                }

                            }
                            break;

                        case "kill":

                            if (enteredValue.Length > 0)                        //if caller has entered a name to search 
                            {
                                for (int i = 0; i < statusList.Count; i++)      //iterate through our TargetList to search for target name if enteredValue is entered.
                                {
                                    if (enteredValue == statusList[i].Name)     //if the given name is on our targetList 
                                    {
                                        if (statusList[i].isFriend == true)     //if he is a friend dont shoot and display message
                                        {
                                            Console.Write("Sorry Captain, we don't permit friendly fire, yar!\n");
                                        }
                                        else if (statusList[i].Status == "Dead")
                                        {
                                            Console.Write("Captain, this bloak is already looking dead to me! Nasty luck mate.\n");
                                        }

                                        else                                    //ortherwise he is an enemy fire on coordinates
                                        {

                                            Console.Write("\nenemy sighted, preparing to fire\n");
                                            Poseidon.command_reset();               //set missle launcher to firing position

                                            double tempX = targetList[i].X;
                                            double tempY = targetList[i].Y;
                                            double tempZ = targetList[i].Z;
                                            double radius = 0;
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            //http://www.learningaboutelectronics.com/Articles/Cartesian-rectangular-to-spherical-coordinate-converter-calculator.php#answer
                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                            radius = Math.Sqrt(Math.Pow(tempX, 2) + Math.Pow(tempY, 2) + Math.Pow(tempZ, 2));  //cartetion product


                                            theta = (180 / Math.PI) * (Math.Acos(tempZ / radius));       //calculating theta which is our up/down
                                            phi = (180 / Math.PI) * (Math.Atan(tempY / tempX));          //calculateing phi which is left/right

                                            if (tempZ == 0)
                                            {
                                                theta = 0;
                                            }

                                            int t = Convert.ToInt32(phi);           //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS+
                                            int t2 = Convert.ToInt32(theta);



                                            if (phi < 0)                            //if entered value is less that zero it is a negative number and will move left.
                                            {
                                                int positive = Math.Abs(t);         //must take absolute value of number to enter into moveLeft function

                                                Poseidon.command_Left(positive);    //missle launcher moves left by amount entered
                                            }
                                            else
                                            {

                                                Poseidon.command_Right(t);          //if entered value is positive then we move right by amount entered
                                            }



                                            if (theta < 0)
                                            {
                                                int positive = Math.Abs(t2);

                                                Poseidon.command_Down(positive);
                                            }
                                            else
                                            {

                                                Poseidon.command_Up(t2);
                                            }

                                            Poseidon.command_Fire();



                                            for (i = 0; i < targetList.Count; i++)      //iterate through our TargetList to search for target name if enteredValue is entered.
                                            {
                                                if (statusList[i].Name == enteredValue)
                                                {
                                                    statusList[i].Status = "Dead";
                                                }
                                            }



                                            Console.Write("\n");
                                        }
                                    }
                                }
                            }

                            break;


                        case "status":
                            Console.WriteLine("Launcher: " + Poseidon.getName() + "\n");
                            Console.WriteLine("\tMissiles:  " + Poseidon.getMissles() + " of 4 remain");
                            break;

                            default:
                            break;
                    }//END Switch case
                }//END While



            }
        }
    }

}