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
        string numberTrackLabelTxt = "YOU DREW AN OMEN! Number track is at ";
        string rolledLabelTxt = "";
        Die dice = new Die();

        public MainPage()
        {
            InitializeComponent();
        }
        void ResetButton_Clicked(object sender, EventArgs e)
        {

            HauntButton.TextColor = Color.FromHex("50C878");
            HauntButton.Text = "Click Me!";
            HauntButton.IsEnabled = true;

            HauntLabel.Text = "";
            RolledLabel.Text = SetRolledText(dice.total, Haunt.numberTrack);

        }
        void HauntButton_Clicked(object sender, EventArgs e)
        {
            OmenLabel.Text = SetNumberTrackText(Haunt.numberTrack, numberTrackLabelTxt);
            
            RolledLabel.Text = SetRolledText(dice.total, Haunt.numberTrack);
            Haunt.AddNumberTrack();
            Haunt.CheckHaunt(dice.total, Haunt.hauntThreshold);

            if (Haunt.hauntFlag == false)
            {
                (sender as Button).Text = "Nothing happens...";
                HauntLabel.Text = "Roll again if you discover another omen...";
            }
            else
            {
                (sender as Button).Text = "SOMETHING HAPPENS, A HAUNT BEGINS!!!";
                (sender as Button).TextColor = Color.FromHex("FF0000");
                (sender as Button).IsEnabled = false;

                HauntLabel.Text = SetNumberTrackText(Haunt.hauntThreshold, "The haunt threshold this time was ");

            }
        }
        public static string SetRolledText(int rolledTotal, int numberTrack)
        {
            return "You rolled a " + rolledTotal + " from " + numberTrack + " dice";
        }

        public static string SetNumberTrackText(int numberTrack, string inputString)
        {
            return inputString + Convert.ToString(numberTrack);
        }

 
    }
}
