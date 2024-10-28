using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Finalwork1
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Restaurant>().Wait();
            _db.CreateTableAsync<Location>().Wait();
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _db.Table<Restaurant>().ToListAsync();
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _db.InsertAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _db.Table<Restaurant>().FirstOrDefaultAsync(r => r.Id == restaurantId);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _db.Table<Restaurant>().FirstOrDefaultAsync(r => r.Id == restaurantId);
            if (restaurant != null)
            {
                await _db.DeleteAsync(restaurant);
            }
        }

        public async Task<List<Restaurant>> GetRestaurantsByLocationAsync(int locationId)
        {
            return await _db.Table<Restaurant>()
                            .Where(r => r.LocationId == locationId)
                            .ToListAsync();
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            return await _db.Table<Location>().ToListAsync();
        }

        public async Task AddLocationAsync(Location location)
        {
            await _db.InsertAsync(location);
        }
    }
}
