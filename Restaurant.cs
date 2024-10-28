using SQLite;

public class Restaurant
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty; // Инициализация по умолчанию
    public string Description { get; set; } = string.Empty; // Инициализация по умолчанию
    public int LocationId { get; set; }
}
