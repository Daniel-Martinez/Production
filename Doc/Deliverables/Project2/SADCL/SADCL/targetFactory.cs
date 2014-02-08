using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADCL
{
    class targetFactory
    {
      
        private static void parser(string line, Target tempTarget) {
            targetFactory iniProduct = new targetFactory();                         //create an object of targetFactory to handel ini Product types
            string[] values = line.Split('=');                          //Split line at '=' and save string in array named values
            iniProduct.lookup[values[0]](values[1], tempTarget);        //go to our lookup dictionary to see associated methed for values.  i.e. if x call setX method.
        
        }

        /////////////////////////////////////////////
        // http://www.dotnetperls.com/dictionary
        // http://www.dotnetperls.com/action
        /////////////////////////////////////////////
        
        public Dictionary<string, Action<string, Target>> lookup;

        public targetFactory() {
            lookup = new Dictionary<string, Action<string, Target>>(){      //what this dictionary says if string found, reference associated method
            {"name", setName},
            {"x", setX},
            {"y", setY},
            {"z", setZ},
            {"friend", setFriend},
            {"flashrate", setFlash},
            {"points", setPoints}
            };
        }

        public static List<Target> Product(string filePath) {

            StreamReader tempFile = new StreamReader(filePath); //tempFile now keeps the path to the file list of Targets

            string line = "";
            int count = 0;
            List<Target> newList = new List<Target>();      //New List to create our Targets
            Target tempTarget = new Target();               //new object of Target Class Type

            while ((line = tempFile.ReadLine()) != null) {
                
                line = line.ToLower();  //Will read in one line of file and convert to lower case

                //////////////////////////////////////////////////////////
                //http://www.dotnetperls.com/split
                //http://www.dotnetperls.com/trim
                //////////////////////////////////////////////////////////

                line = line.Split('#')[0].Trim();           //This will clip white space and remove comments in file.

                if (line.Length < 1) {                      //This will skip blank rows in file
                    ++count;                                //increment count
                    continue;                               //allows program to continue with out retunrning
                }

                if (line == "[target]") {       

                    if (tempTarget.isDone || newList.Count > 0) {   //adding to our object when all values are defined
                        newList.Add(tempTarget);
                    }

                    tempTarget = new Target();              //create our next Target
                }

                else if (line.Contains('=')) {              //if the line contains an '=' sign than it has an attribute for our target  
                    
                    parser(line, tempTarget);               //pass it to be parsed

                }

                ++count;                                    //increment count
                
            }


            if (tempTarget.isDone) {
                newList.Add(tempTarget);
            }

            for (int i = 0; i < newList.Count; i++) {
                if (!newList[i].isDone) {
                    Console.Write("Not all Target Data Entered!");
                }
            }

            tempFile.Close();
            return newList;

        
        } //END Product method

        public void setName(string line, Target iniTarget){         //Setting the name of our target
    
        string tempName = line;
            if(tempName.Contains(' ')){
                Console.Write("Invalid Target Name.");
            }

            tempName = String.Join("", tempName.Split('"'));
            iniTarget.Name = tempName;
        
        }//END set name

        ///////////////////////////////////////////////
        /// <http://www.dotnetperls.com/int-tryparse
        /////////////////////////////////////////////// 

        public void setX(string line, Target iniTarget)         //Seeting X coordinate
        {           

            double tempValue = 0.0;
            if (double.TryParse(line, out tempValue))
            {
                iniTarget.X = tempValue;
            }
            else {
                Console.Write("Invalid X coordinate");
            }

        }//END setX

        public void setY(string line, Target iniTarget)         //Seeting Y coordinate
        {

            double tempValue = 0.0;
            if (double.TryParse(line, out tempValue))
            {
                iniTarget.Y = tempValue;
            }
            else
            {
                Console.Write("Invalid Y coordinate");
            }

        }//END setY

        public void setZ(string line, Target iniTarget)         //Seeting Z coordinate
        {

            double tempValue = 0.0;
            if (double.TryParse(line, out tempValue))
            {
                iniTarget.Z = tempValue;
            }
            else
            {
                Console.Write("Invalid Z coordinate");
            }

        }//END setZ

        public void setFriend(string line, Target iniTarget)    //Setting Friend or Foe
        {
            bool temp = false;
            if (bool.TryParse(line, out temp))
            {
                iniTarget.isFriend = temp;
            }
            else 
            {
                Console.Write("Value for Freindly Target incorrect.");
            }

        }//END setFriend

        public void setPoints(string line, Target iniTarget)    //setting targets value
        {
            int temp = 0;
            if(int.TryParse(line, out temp)){
                iniTarget.score = temp;
            }
            else
            {
                Console.Write("Invalid value for Points");
            }
               
        }//END setPoints

        public void setFlash(string line, Target iniTarget) 
        {
            int temp = 0;
            if (int.TryParse(line, out temp))
            {
                iniTarget.flashTime = temp;
            }
            else 
            {
                Console.Write("Invalid Flash Value");
            }
        }//END setFlash

    }
}
