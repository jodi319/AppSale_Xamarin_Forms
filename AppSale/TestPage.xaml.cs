using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppSale
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        
        async void OnCreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFavourite());
        }

        async void OnReadClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetFavourites());
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetFavourites());
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new GetFavourites());
            MessageBox.Show(":");
        }
    }
}
