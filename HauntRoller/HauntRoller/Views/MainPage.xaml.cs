using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HauntRoller
{
    public partial class MainPage : ContentPage
    {
        Die dice = new Die();
        
        public MainPage()
        {
            Haunt.ResetHaunt(); //need to reset haunt as the page initialises, so that the haunt randomiser can activate
   
            InitializeComponent();
            BackgroundImageSource = "teastain.jpeg";
        }
        void ResetButton_Clicked(object sender, EventArgs e)
        {
            Haunt.ResetHaunt();
            dice.ResetDice();
            HauntButton.TextColor = Color.FromHex("50C878");
            HauntButton.Text = "Click Me!";

            OmenLabel.Text = "";
            HauntLabel.Text = "";
            RolledLabel.Text = "";
        }
        void HauntButton_Clicked(object sender, EventArgs e)
        {
            if (Haunt.hauntFlag == false)
            {
                dice.RollDice(Haunt.numberTrack);
                OmenLabel.Text = "YOU DREW AN OMEN! Number track is at " + Haunt.numberTrack;
                RolledLabel.Text = "You rolled a " + dice.total + "! ( " + dice.PrintDice() + ")";

                if (Haunt.CheckHaunt(dice.total) == false)
                {
                    (sender as Button).Text = "Nothing happens...";
                }
                else
                {
                    (sender as Button).Text = "SOMETHING HAPPENS...\nA HAUNT BEGINS";
                    (sender as Button).TextColor = Color.FromHex("FF0000");

                    HauntLabel.Text = "The haunt threshold this time was " + Haunt.hauntThreshold;
                }
            }
        }


 
    }
}
