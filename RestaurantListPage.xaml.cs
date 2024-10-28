using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finalwork1
{
    public partial class RestaurantListPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly Location _location;

        public RestaurantListPage(DatabaseService databaseService, Location location)
        {
            InitializeComponent();
            _databaseService = databaseService;
            _location = location;
            Title = _location.Name;
            LoadRestaurants();
        }

        private async void LoadRestaurants()
        {
            var restaurants = await _databaseService.GetRestaurantsByLocationAsync(_location.Id);
            RestaurantListView.ItemsSource = restaurants;
        }

        private async void OnRestaurantSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Restaurant selectedRestaurant)
            {
                await Navigation.PushAsync(new RestaurantDetailPage(_databaseService, selectedRestaurant));
            }
        }

        private async void OnAddRestaurantButtonClicked(object sender, EventArgs e)
        {
            // Открытие формы 
            string name = await DisplayPromptAsync("Добавить ресторан", "Введите имя ресторана:");
            string description = await DisplayPromptAsync("Добавить ресторан", "Введите описание ресторана:");

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(description))
            {
                var newRestaurant = new Restaurant
                {
                    Name = name,
                    Description = description,
                    LocationId = _location.Id 
                };

                await _databaseService.AddRestaurantAsync(newRestaurant);
                LoadRestaurants(); 
            }
        }

        private async void OnDeleteRestaurantClicked(object sender, EventArgs e)
        {
            if (RestaurantListView.SelectedItem is Restaurant selectedRestaurant)
            {
                bool confirm = await DisplayAlert("Подтверждение", "Вы уверены, что хотите удалить этот ресторан?", "Да", "Нет");
                if (confirm)
                {
                    await _databaseService.DeleteRestaurantAsync(selectedRestaurant.Id);
                    LoadRestaurants(); 
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Пожалуйста, выберите ресторан для удаления.", "OK");
            }
        }
    }
}
