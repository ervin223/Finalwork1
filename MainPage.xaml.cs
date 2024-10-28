using Microsoft.Maui.Controls;

namespace Finalwork1
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        private async void OnViewRestaurantsButtonClicked(object sender, EventArgs e)
        {
            var location = new Location { Id = 1, Name = "Локация 1" }; 
            await Navigation.PushAsync(new RestaurantListPage(_databaseService, location));
        }
    }
}
