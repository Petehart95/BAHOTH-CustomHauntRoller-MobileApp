using System;
using System.Collections.Generic;
using System.Text;

namespace HauntRoller
{
    class Haunt
    {
        public static int numberTrack;
        public static int hauntThreshold;
        public static bool hauntFlag = false;

        //constructor
        //public Haunt ()
        //{
        //    numberTrack = 0;
        //    HauntRandomiser();
        //    hauntFlag = false;
        //}
        
        //randomly assign a threshold which will trigger a haunt
        public static void HauntRandomiser()
        {
            Random rnd = new Random();
            hauntThreshold = rnd.Next(4, 12);
        }

        public static void AddNumberTrack()
        {
            if (numberTrack != 9)
            {
                numberTrack++;
            }
        }

        //check if the rolled amount exceeds the threshold
        public static bool CheckHaunt(int total)
        {
            if (total >= hauntThreshold)
            {
                return hauntFlag = true;
            }
            else
            {
                AddNumberTrack();
                return hauntFlag = false;
            }


        }
        //when the game is over, you can reset the haunt variables
        public static void ResetHaunt()
        {
            numberTrack = 0;
            HauntRandomiser();
            hauntFlag = false;
        }
    }
}
