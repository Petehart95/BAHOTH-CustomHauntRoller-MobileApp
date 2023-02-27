using System;
using System.Collections.Generic;
using System.Text;

namespace HauntRoller
{
    class Haunt
    {
        public static int numberTrack;
        public static int hauntThreshold;
        public static bool hauntFlag;

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
            hauntThreshold = rnd.Next(4, 8);
        }

        public static void AddNumberTrack()
        {
            numberTrack++;
        }

        //check if the rolled amount exceeds the threshold
        public static void CheckHaunt(int total, int threshold)
        {
            if (total >= threshold)
            {
                hauntFlag = true;
            }
            else
            {
                hauntFlag = false;
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
