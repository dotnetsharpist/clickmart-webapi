using Npgsql;

namespace ClickMart.DataAccess.Repositories;

public class BaseRepository
{
    public readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=ClickMart-db;User Id=postgres;Password=muslim571");
    }
}