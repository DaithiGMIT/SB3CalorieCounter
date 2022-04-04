using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalorieCounter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalSettingPage : ContentPage
    {
        public GoalSettingPage()
        {
            InitializeComponent();
            LblDailyGoal.Text = "Current Daily Goal: " + Profile.dailyGoals;
            LblWeeklyGoal.Text = "Current Weekly Goal: " + Profile.weeklyGoals;
        }

        private void DailyGoal_Clicked(object sender, EventArgs e)
        {
            Profile.updateGoals(1, EntryGoalSet.Text);
            LblDailyGoal.Text = "Current Daily Goal: " + Profile.dailyGoals;
        }

        private void WeeklyGoal_Clicked(object sender, EventArgs e)
        {
            Profile.updateGoals(2, EntryGoalSet.Text);
            LblWeeklyGoal.Text = "Current Weekly Goal: " + Profile.weeklyGoals;
        }

        private async void MainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}