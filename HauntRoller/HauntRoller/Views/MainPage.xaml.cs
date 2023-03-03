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
            InitializeComponent();
            CheckSettings();
            Haunt.ResetHaunt(); //need to reset haunt as the page initialises, so that the haunt randomiser can activate
            BackgroundImageSource = "teastain.jpeg";
        }
        void ResetButton_Clicked(object sender, EventArgs e)
        {
            Haunt.ResetHaunt();
            dice.ResetDice();
            AutoHauntButton.TextColor = Color.FromHex("50C878");
            AutoHauntButton.Text = "Roll and Check Haunt";

            ManHauntButton.TextColor = Color.FromHex("50C878");
            ManHauntButton.Text = "Check Haunt";
            ManRollEntry.Text = "";

            OmenLabel.Text = "";
            HauntLabel.Text = "";
            RolledLabel.Text = "";
        }
        void AutoHauntButton_Clicked(object sender, EventArgs e)
        {
            if (Haunt.hauntFlag == false)
            {
                dice.RollDice(Haunt.numberTrack);
                OmenLabel.Text = "Number track is at " + Haunt.numberTrack;
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
        void ManHauntButton_Clicked(object sender, EventArgs e)
        {
            if (Haunt.hauntFlag == false  && ManRollEntry.Text.Length > 0)
            {
                dice.total = Convert.ToInt32(ManRollEntry.Text);
                OmenLabel.Text = "Number track is at " + Haunt.numberTrack;
                RolledLabel.Text = "You rolled a " + dice.total + "!";
                ManRollEntry.Text = "";

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

        void CheckSettings()
        {
            if (SettingsHandler.diceEnabled == true)
            {
                //dice rolls
                AutoHauntButton.IsVisible = true;
                
                //manual rolls
                ManHauntButton.IsVisible = false;
                ManLabel.IsVisible = false;
                ManRollEntry.IsVisible = false;
            }
            else
            {
                //dice rolls
                AutoHauntButton.IsVisible = false;
                //manual rolls
                ManHauntButton.IsVisible = true;
                ManLabel.IsVisible = true;
                ManRollEntry.IsVisible = true;
            }
        }

        void SettingsButtonClicked_Handler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }


    }
}
