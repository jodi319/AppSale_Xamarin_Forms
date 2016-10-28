using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppSale
{
    public partial class GetFavourites : ContentPage
    {
        TodoItemManager manager;
        Favourites favourites;

        public GetFavourites()
        {
            InitializeComponent();

            manager = TodoItemManager.DefaultManager;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Refresh items only when authenticated.
        //    if (authenticated == true)
        //    {
        //        // Set syncItems to true in order to synchronize the data 
        //        // on startup when running in offline mode.
        //        await RefreshItems(true, syncItems: false);

        //        // Hide the Sign-in button.
        //        this.loginButton.IsVisible = false;
        //    }
        //}

        public async void GetClick(object sender, EventArgs e)
        {
            Favourites favourites = new Favourites();
            await GetItem();
        }

        async Task GetItem()
        {
            Favourites favourite = new Favourites();
            ListView myListView = new ListView();

            myListView.ItemsSource =  await manager.GetFavouritesAsync();
            //todoList.ItemsSource = await manager.GetTodoItemsAsync();
        }
    }
}
