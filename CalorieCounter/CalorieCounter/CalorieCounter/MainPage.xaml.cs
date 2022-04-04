using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalorieCounter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Profile.createProfile();
            Profile.checkDailyCals();
            Profile.checkWeeklyCals();
            WelcomeLabel.Text = "Welcome " + Profile.username;
            LblTodayCals.Text = "Todays Calories: " + Profile.dailyCals;
            LblWeeklyCals.Text = "Weekly Calories: " + Profile.weeklyCals;
            LblGoalCals.Text = "Goal Calories: " + Profile.dailyCals + "/" + Profile.dailyGoals;

        }

        private async void EnterCalories_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalorieEntryPage());
        }

        private async void VeiwCalories_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreviousCaloriePage());
         }

        private async void SetGoals_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoalSettingPage());
        }
    }
}
