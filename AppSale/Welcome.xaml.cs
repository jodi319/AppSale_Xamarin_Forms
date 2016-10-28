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
        bool authenticated = false;                                     // Track whether the user has authenticated. 

        public Welcome()
        {
            InitializeComponent();
            
        }

        //SelectMultipleBasePage<CheckItem> multiPage;
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //DELETE THIS
            AppSale.Helpers.Settings.InitFavSet = true;
            if (AppSale.Helpers.Settings.InitFavSet)
            {
                await Navigation.PushAsync(new GetFavourites());
                //await Navigation.PushAsync(new AddFavourite());
                //await Navigation.PushAsync(new TodoList());
                //await Navigation.PushModalAsync(multiPage);
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
            try
            {

                if (App.Authenticator != null)
                {
                    authenticated = await App.Authenticator.Authenticate();
                }

                if (authenticated)
                {
                    //DELETE THIS
                    AppSale.Helpers.Settings.InitFavSet = true;
                    if (AppSale.Helpers.Settings.InitFavSet)
                    {
                        await Navigation.PushAsync(new GetFavourites());
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
    }
}
