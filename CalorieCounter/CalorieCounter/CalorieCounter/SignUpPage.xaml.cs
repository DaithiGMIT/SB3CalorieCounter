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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private Boolean confirmPassword(string s1, string s2)
        {
            if(s1 == s2)
            {
                return true;
            }

            return false;
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {

            string username = entryUsername.Text;
            string password = entryPassword.Text;
            string passwordConfirm = entryPasswordConfirm.Text;
            bool passwordCheck = confirmPassword(password, passwordConfirm);
            int usernameCheck = Transporter.checkUsernames(username);

            if(usernameCheck == -1 && passwordCheck == true)
            {
                Transporter.userName = username;
                Transporter.addNewUser(username, password);
                await Navigation.PushAsync(new MainPage());
            }

            else if(usernameCheck != -1)
            {
                lblNotify.Text = "Username Allready Exists!";
                lblNotify.TextColor = Color.Red;
            }
            
            else if(usernameCheck == -1 && password != passwordConfirm)
            {
                lblNotify.Text = "Passwords Don't Match!";
                lblNotify.TextColor = Color.Red;
            }




        }
    }
}