using Microsoft.Maui.Controls;

namespace Finalwork1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Путь к базе данных
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "restaurants.db");
            var databaseService = new DatabaseService(dbPath);

            // Передача databaseService в MainPage
            MainPage = new NavigationPage(new MainPage(databaseService));
        }
    }
}
