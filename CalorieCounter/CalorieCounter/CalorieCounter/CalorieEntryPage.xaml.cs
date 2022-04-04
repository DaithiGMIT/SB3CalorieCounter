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
    public partial class CalorieEntryPage : ContentPage
    {
        public CalorieEntryPage()
        {
            InitializeComponent();
            LblDailyCals.Text = "Daily Calories: " + Profile.dailyCals;
        }

        private async void MainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void AddCalories_Clicked(object sender, EventArgs e)
        {
            Profile.addCalories(EntryCalories.Text);
            LblDailyCals.Text = "Daily Calories: " + Profile.dailyCals;
        }
    }
}