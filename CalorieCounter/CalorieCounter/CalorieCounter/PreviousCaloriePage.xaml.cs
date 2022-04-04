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
    public partial class PreviousCaloriePage : ContentPage
    {
        public PreviousCaloriePage()
        {
            InitializeComponent();
            LblDisplay.Text = "Daily Calories Total = " + Profile.dailyCals;
        }

        private void ShowPreviousDay_Clicked(object sender, EventArgs e)
        {
            Profile.displayYesterdayCals();
        }

        private void ShowPreviousWeek_Clicked(object sender, EventArgs e)
        {
            LblDisplay.Text = "Weekly Calories Total = " + Profile.weeklyCals;
        }

        private void SearchDate_Clicked(object sender, EventArgs e)
        {
            LblDisplay.Text = Profile.displayDateCals(EntrySearchDate.Text);
        }

        private async void MainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}