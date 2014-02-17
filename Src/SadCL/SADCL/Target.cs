using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SADCL
{
    class target                    //target class to create target objects
    {
        private string name;
        private double Xcord;
        private double Ycord;
        private double Zcord;           //variables to hold Target Data
        private bool friend;
        private int points;
        private int flashRate;
        private bool done;
        private int[] targetlist;
        private string status;

        public target()  //default constructor, set or bool to false and int array to 8 to keep track of object items
        {
            done = false;
            targetlist = new int[8];
            
        }

        public string Name  //getter and setter for target Name
        {
            get { return name; }
            set
            {
                name = value;
                targetlist[0] = 1;
            }
        }


        public double X     //getter and setter for target X coordinate
        {
            get { return Xcord; }
            set
            {
                Xcord = value;
                targetlist[1] = 1;
            }
        }

        public double Y     //getter and setter for target Y coordinate
        {
            get { return Ycord; }
            set
            {
                Ycord = value;
                targetlist[2] = 1;
            }
        }

        public double Z     //getter and setter for target Z coordinate
        {
            get { return Zcord; }
            set
            {
                Zcord = value;
                targetlist[3] = 1;
            }
        }


        public bool isFriend        //getter and setter for target friend or foe value
        {
            get { return friend; }
            set
            {
                friend = value;
                targetlist[4] = 1;
            }
        }

        public int score        //getter and setter for target value/ score
        {
            get { return points; }
            set
            {
                points = value;
                targetlist[5] = 1;
            }
        }

        public int flashTime    //getter and setter for target flashTime, represents a moving target
        {
            get { return flashRate; }
            set
            {
                flashRate = value;
                targetlist[6] = 1;
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                targetlist[7] = 1;
            }
        }

        public bool isDone  //getter and setter for target done value, quick loop to see if all values have been set for an object, used by targetFactory to create whole Target object
        {
            get
            {

                int temp = 0;

                for (int i = 0; i < 8; i++)
                {

                    if (targetlist[i] == 1)
                    {
                        temp++;
                    }
                }

                if (temp >= 8)      //Majic number '8' to account for the number of fields/attributes to specify one target
                {
                    done = true;
                }
                return done;
            }

            set { done = value; }
        }//END isDone

    }//END Class Target
}
