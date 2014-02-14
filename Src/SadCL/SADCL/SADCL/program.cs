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
                
                List<target> targetList = targetFactory.Product(path);    //object targetList is a product of Factory containing all Target data read in from file

                singleton tempObj = singleton.getInstance();
                List<target> statusList = tempObj.getList();

                statusList = targetList;

                //for (int i = 0; i <= targetList.Count; i++)
                //{
                //    statusList[i] = targetList[i];
                //}

                missileFactory Billy = new missileFactory();  // missile launcher is created
                Console.WriteLine("Would you like the real deal Hollifield or just a Mock\n Please press M or a mock or R for a real turret");
                //string input = Console.ReadLine().ToLower();               //user input
                
                /**********************************************************************************/
                MissileLauncher Poseidon =  Billy.product();
                Poseidon.reload();                               // fully loaded and ready to fire. 
                Poseidon.name = "Beef_Cake";                     // name turret
                string convInput = "";                           //Holds value for string when Split
                string enteredValue = "";                        //Holds user entered value for menu
                string enteredValue2 = "";                       //Holds user entered value for menu


                string input = Console.ReadLine().ToLower(); 
                while (input != "exit")
                {
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
                            //Poseidon.missiles = Poseidon.missiles--;
                            break;

                        case "reset":
                            Poseidon.command_reset();                        
                            break;
                        
                        case "move":
                            
                            double phi = 0;                         //create a value to store our phi, which is x,y left/right
                            phi = Convert.ToDouble(enteredValue);   //converts entered value to a double
                            int temp = Convert.ToInt32(phi);        //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS
                            if (phi < 0)                            //if entered value is less that zero it is a negative number and will move left.
                            {
                                int positive = Math.Abs(temp);      //must take absolute value of number to enter into moveLeft function
                                Poseidon.command_Left(positive);        //missle launcher moves left by amount entered
                            }
                            else
                            {
                            Poseidon.command_Right(temp);               //if entered value is positive then we move right by amount entered
                            }
                            
                            double theta = 0;                       //create a value to store our theta, which is Z up/down
                            theta = Convert.ToDouble(enteredValue2);
                            int temp2 = Convert.ToInt32(theta);     //simalar to above
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
                        
                        case "moveby":

                            phi = 0;                         //create a value to store our phi, which is x,y left/right
                            phi = Convert.ToDouble(enteredValue);   //converts entered value to a double
                            temp = Convert.ToInt32(phi);        //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS
                            if (phi < 0)                            //if entered value is less that zero it is a negative number and will move left.
                            {
                                int positive = Math.Abs(temp);      //must take absolute value of number to enter into moveLeft function
                                Poseidon.command_Left(positive);        //missle launcher moves left by amount entered
                            }
                            else
                            {
                                Poseidon.command_Right(temp);               //if entered value is positive then we move right by amount entered
                            }

                            theta = 0;                       //create a value to store our theta, which is Z up/down
                            theta = Convert.ToDouble(enteredValue2);
                            temp2 = Convert.ToInt32(theta);     //simalar to above
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
                        
                        case "reload":
                            Poseidon.reload();
                            break;
                        
                        case "load":
                            path = enteredValue;

                            if (!File.Exists(path))
                            {
                                System.Console.WriteLine("yeh thats just a bad file.\n");
                            }
                            else
                            {
                                targetList = targetFactory.Product(path);
                                Console.Write("argghh argghh new targets in sight!!\n\n");
                            }
                            break;

                        case "kill":


                            if (enteredValue.Length > 0)                        //if caller has entered a name to search 
                            {
                                for (int i = 0; i < targetList.Count; i++)      //iterate through our TargetList to search for target name if enteredValue is entered.
                                {
                                    if (enteredValue == targetList[i].Name)     //if the given name is on our targetList 
                                    {
                                        if (targetList[i].isFriend == true)     //if he is a friend dont shoot and display message
                                        {
                                            Console.Write("Sorry Captain, we don't permit friendly fire, yar");
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

                                            Console.Write(tempZ);
                                            theta = (180 / Math.PI) * (Math.Acos(tempZ / radius));       //calculating theta which is our up/down
                                            phi = (180 / Math.PI) * (Math.Atan2(tempY, tempX));        //calculateing phi which is left/right

                                            Console.Write("Theta =" + theta);
                                            int t = Convert.ToInt32(phi);        //converts to int because our missleLauncher only understands integers, ### WE NEED TO ASK ABOUT THIS+
                                            int t2 = Convert.ToInt32(theta);



                                            if (phi < 0)                         //if entered value is less that zero it is a negative number and will move left.
                                            {
                                                int positive = Math.Abs(t);     //must take absolute value of number to enter into moveLeft function

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

                                            Console.Write("Fire missle here BOOM!!!");



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
                            Console.WriteLine("Launcher: "+ Poseidon.name + "\n");
                            Console.WriteLine("\tMissiles:  " + Poseidon.getMissles() + " of 4 remain");
                            break;

                        case "friends":
                            
                                for (int i = 0; i < targetList.Count; i++)
                                {
                                    if (targetList[i].isFriend == true)     //if value for out Target isFriend is true he's cool
                                    {
                                            Console.Write("Target: "+targetList[i].Name + "\n");
                                            Console.Write("Friend: One of us\n");
                                            Console.Write("Position: " + " x=" + targetList[i].X + ", y=" + targetList[i].Y+ ", z=" + targetList[i].Z + "\n");
                                            Console.Write("Points: " + targetList[i].score + "\n");
                                            Console.Write("Status: " +targetList[i].Status +"\n");
                                            Console.Write("\n");
                                    }

                                }
                                break;
                        case "state":

                                for (int i = 0; i < statusList.Count; i++)
                                {
                                    
                                        Console.Write("Target: " + targetList[i].Name + "\n");
                                        Console.Write("Friend: One of us\n");
                                        Console.Write("Position: " + " x=" + targetList[i].X + ", y=" + targetList[i].Y + ", z=" + targetList[i].Z + "\n");
                                        Console.Write("Points: " + targetList[i].score + "\n");
                                        Console.Write("Status: " + targetList[i].Status + "\n");
                                        Console.Write("\n");
                                    

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
                                        Console.Write("Status: "+ targetList[i].Status +"\n");
                                        Console.Write("\n");
                                    }

                                }
                                break;
                        default:
                            break;
                    }//END Switch case
                }//END While



            }
        }
    }
}
