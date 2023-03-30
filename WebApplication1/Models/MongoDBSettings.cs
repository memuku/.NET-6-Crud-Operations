namespace Dot6.MongoDb.API.CRUD.Models;

public class MongoDBSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } =null!;
    public string CollectionName { get; set; } = null!;
}
