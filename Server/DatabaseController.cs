using MySqlConnector;

namespace Server;

public interface IDatabaseController {
    Task<int> ExecuteAsync(string sql, Dictionary<string, object>? parameters = null);
    Task<List<Dictionary<string, object>>> QueryAsync(string sql, Dictionary<string, object>? parameters = null);
    Task<T?> ScalarAsync<T>(string sql, Dictionary<string, object>? parameters = null);
}

public sealed class DatabaseController : IDatabaseController {
    private readonly string _connectionString;

    public DatabaseController(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public async Task<int> ExecuteAsync(string sql, Dictionary<string, object>? parameters = null) {
        await using MySqlConnection conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();
        await using MySqlCommand cmd = new MySqlCommand(sql, conn);
        AddParams(cmd, parameters);
        return await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<Dictionary<string, object>>> QueryAsync(
        string sql, Dictionary<string, object>? parameters = null) {
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        await using MySqlConnection conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();
        await using MySqlCommand cmd = new MySqlCommand(sql, conn);
        AddParams(cmd, parameters);
        await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync()) {
            Dictionary<string, object> row = new Dictionary<string, object>(reader.FieldCount);
            for (int i = 0; i < reader.FieldCount; i++) {
                row[reader.GetName(i)] = await reader.IsDBNullAsync(i) ? null! : reader.GetValue(i);
            }

            rows.Add(row);
        }

        return rows;
    }

    public async Task<T?> ScalarAsync<T>(string sql, Dictionary<string, object>? parameters = null) {
        await using MySqlConnection conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();
        await using MySqlCommand cmd = new MySqlCommand(sql, conn);
        AddParams(cmd, parameters);
        object? result = await cmd.ExecuteScalarAsync();
        if (result == null || result is DBNull) return default;
        return (T)Convert.ChangeType(result, typeof(T));
    }

    private static void AddParams(MySqlCommand cmd, Dictionary<string, object>? parameters) {
        if (parameters == null) return;
        foreach (KeyValuePair<string, object> kv in parameters)
            cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
    }
}