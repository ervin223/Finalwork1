using Microsoft.Maui.Controls;

namespace Finalwork1
{
    public partial class RestaurantDetailPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly Restaurant _restaurant;

        public RestaurantDetailPage(DatabaseService databaseService, Restaurant restaurant)
        {
            InitializeComponent();
            _databaseService = databaseService;
            _restaurant = restaurant;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadRestaurantDetails();
        }

        private async Task LoadRestaurantDetails()
        {
            var restaurant = await _databaseService.GetRestaurantByIdAsync(_restaurant.Id);
            if (restaurant != null)
            {
                NameLabel.Text = restaurant.Name;
                DescriptionLabel.Text = restaurant.Description;
            }
        }
    }
}
