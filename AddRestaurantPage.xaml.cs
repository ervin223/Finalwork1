using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Finalwork1
{
    public partial class AddRestaurantPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public AddRestaurantPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        private async void OnAddRestaurantClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var description = DescriptionEditor.Text;

            // Проверка на наличие текста
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                await DisplayAlert("Ошибка", "Имя и описание не могут быть пустыми.", "OK");
                return;
            }

            var restaurant = new Restaurant
            {
                Name = name,
                Description = description,
                LocationId = 1 // Здесь вы можете задать нужный ID локации
            };

            await _databaseService.AddRestaurantAsync(restaurant);
            await Navigation.PopAsync(); // Вернуться на предыдущую страницу
        }
    }
}
