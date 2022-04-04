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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            int check = Transporter.checkUsernames(UserName.Text);


            if (check == -1)
            {
                LblUsername.Text = "Username not found";
                LblUsername.TextColor = Color.Red;

                LblPassword.Text = "Password";
                LblPassword.TextColor = Color.Black;
            }

            else if (check != -1)
            {
                if(Transporter.checkPassword(password.Text, check) == true)
                {
                    Transporter.userName = UserName.Text;
                    await Navigation.PushAsync(new MainPage());
                }

                else
                {
                    LblUsername.Text = "Username";
                    LblUsername.TextColor = Color.Black;

                    LblPassword.Text = "Password Incorrect";
                    LblPassword.TextColor = Color.Red;
                }
            }

        }
    }
}