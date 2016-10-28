using Multiselect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppSale
{
    public partial class Welcome : ContentPage
    {
        bool authenticated = false;
        // Track whether the user has authenticated. 
        SelectMultipleBasePage<CheckItem> multiPage;

        public Welcome()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Refresh items only when authenticated.
            if (authenticated == true)
            {
                // Set syncItems to true in order to synchronize the data 
                // on startup when running in offline mode.
                //await RefreshItems(true, syncItems: false);
                
                // Hide the Sign-in button.
                this.loginButton.IsVisible = false;
                this.facebookLoginButton.IsVisible = false;
                this.registerButton.IsVisible = false;
                this.forgotButton.IsVisible = false;
                this.logoutButton.IsVisible = true;
            }
            else
            {
                this.loginButton.IsVisible = true;
            this.facebookLoginButton.IsVisible = true;
            this.registerButton.IsVisible = true;
            this.forgotButton.IsVisible = true;
            this.logoutButton.IsVisible = false;
            }

        }

        //SelectMultipleBasePage<CheckItem> multiPage;
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //DELETE THIS------------------------------
            AppSale.Helpers.Settings.InitFavSet = true;
            //-----------------------------------------
            if (AppSale.Helpers.Settings.InitFavSet)
            {
                //await Navigation.PushAsync(new GetFavourites());
                //await Navigation.PushAsync(new AddFavourite());
                //await Navigation.PushAsync(new TodoList());
                //await Navigation.PushModalAsync(multiPage);
                //-----------------------------------------------------------------------------------------------
                var items = new List<CheckItem>();
                items.Add(new CheckItem { Name = "Xamarin.com" });
                items.Add(new CheckItem { Name = "Twitter" });
                items.Add(new CheckItem { Name = "Facebook" });
                items.Add(new CheckItem { Name = "Internet ad" });
                items.Add(new CheckItem { Name = "Online article" });
                items.Add(new CheckItem { Name = "Magazine ad" });
                items.Add(new CheckItem { Name = "Friends" });
                items.Add(new CheckItem { Name = "At work" });


                //todoList.ItemsSource = items;
                if (multiPage == null)
                    multiPage = new SelectMultipleBasePage<CheckItem>(items) { Title = "Check all that apply" };

                await Navigation.PushModalAsync(multiPage);
                //await Navigation.PushAsync(multiPage);
                //----------------------------------------------------------------------------------------------------
                AppSale.Helpers.Settings.InitFavSet = false;
            }
            else
            {
                await Navigation.PushModalAsync(new Sale());
            }
        }

        public void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Screen that handles registration", "OK");
        }

        public void OnForgotButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert","Screen that handles password and-or username login details retrieval", "OK");
        }

        async void OnFacebookLoginButtonClicked(object sender, EventArgs e)
        {
            //try
            //{

            //if (App.Authenticator != null)
            //{
            //    authenticated = await App.Authenticator.AuthenticateAsync();
            //}

            //if (authenticated)
            //{
            //    Navigation.InsertPageBefore(new TestPage(), this);
            //    await Navigation.PopAsync();
            //}
            //}
            //catch (InvalidOperationException ex)
            //{
            //    if (ex.Message.Contains("Authentication was cancelled"))
            //    {
            //        messageLabel.Text = "Authentication cancelled by the user";
            //    }
            //}
            //catch (Exception)
            //{
            //    messageLabel.Text = "Authentication failed";
            //}
            try
            {

                if (App.Authenticator != null)
                {
                    authenticated = await App.Authenticator.AuthenticateAsync();
                }

                if (authenticated)
                {
                    //DELETE THIS
                    AppSale.Helpers.Settings.InitFavSet = true;
                    if (AppSale.Helpers.Settings.InitFavSet)
                    {
                        await Navigation.PushAsync(new TestPage());
                        //await Navigation.PushAsync(new AddFavourite());
                        //await Navigation.PushAsync(new TodoList());
                        //await Navigation.PushModalAsync(multiPage);
                        AppSale.Helpers.Settings.InitFavSet = false;
                    }
                    else
                    {
                        await Navigation.PushModalAsync(new Sale());
                    }
                    //Navigation.InsertPageBefore(new TodoList(), this);
                    //await Navigation.PopAsync();
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {
                    messageLabel.Text = "Authentication cancelled by the user";
                }
            }
            catch (Exception)
            {
                messageLabel.Text = "Authentication failed";
            }

            //Navigation.InsertPageBefore(new TodoList(), this);
            //await Navigation.PopAsync();
            //await Navigation.PopAsync();
            //Navigation.PushAsync(new TodoList());

            //The simplest technique for passing data to another page during navigation is through a page constructor parameter
            //.MainPage = new NavigationPage(new MainPage(DateTime.Now.ToString("u")));
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            bool loggedOut = false;

            if (App.Authenticator != null)
            {
                loggedOut = await App.Authenticator.LogoutAsync();
            }

            if (loggedOut)
            {
                Navigation.InsertPageBefore(new Welcome(), this);
                await Navigation.PopAsync();
            }
        }
    }
}