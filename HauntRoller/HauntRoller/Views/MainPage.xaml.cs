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

        string rolledLabelTxt = "";
        Die dice = new Die();
        
        public MainPage()
        {
            Haunt.ResetHaunt();
   
            InitializeComponent();
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

            //HauntButton.IsEnabled = true;
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
                    HauntLabel.Text = "Roll again if you discover another omen...";
                }
                else
                {
                    (sender as Button).Text = "SOMETHING HAPPENS, A HAUNT BEGINS!!!";
                    (sender as Button).TextColor = Color.FromHex("FF0000");

                    HauntLabel.Text = "The haunt threshold this time was " + Haunt.hauntThreshold;

                    //(sender as Button).IsEnabled = false;
                }
            }
        }


 
    }
}
