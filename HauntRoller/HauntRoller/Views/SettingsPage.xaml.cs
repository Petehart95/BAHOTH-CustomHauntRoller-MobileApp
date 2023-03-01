using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HauntRoller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        public SettingsPage()
        {

            InitializeComponent();
            SettingsButtonInitialiser();
            BackgroundImageSource = "teastain.jpeg";
        }
        void SettingsButtonInitialiser()
        {
            if (SettingsHandler.diceEnabled == true)
            {
                DiceToggleButton.Text = "On";
            }
            else
            {
                DiceToggleButton.Text = "Off";
            }
        }
        private async void BackButtonClicked_Handler(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), true);
        }
        private void DiceToggleButtonClicked_Handler(object sender, EventArgs e)
        {
            if(SettingsHandler.diceEnabled == true)
            {
                SettingsHandler.diceEnabled = false;
                (sender as Button).Text = "Off";
            }
            else
            {
                SettingsHandler.diceEnabled = true;
                (sender as Button).Text = "On";                
            }
        }
    }
}