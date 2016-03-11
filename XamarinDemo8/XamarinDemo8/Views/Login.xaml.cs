using System;
using Xamarin.Forms;

namespace XamarinDemo8.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);

            btnLogin.Clicked += BtnLoginOnClicked;
        }

        private void BtnLoginOnClicked(object sender, EventArgs eventArgs)
        {
            var loginService = new Services.LoginService();

            if (loginService.Login(txtUserName.Text, txtPassword.Text))
            {
                Navigation.PushAsync(new Landing(), true);
                Navigation.RemovePage(this);
            }
            else
            {
                DisplayAlert("Login Failure", "Invalid username or password", "OK");
            }
        }
    }
}