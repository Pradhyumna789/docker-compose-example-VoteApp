using StackExchange.Redis;
using System.Threading;
using Npgsql;

var redis = ConnectionMultiplexer.Connect("redis");
var db = redis.GetDatabase();
var connString = "Host=db;Username=postgres;Password=postgres;Database=votes";
using var conn = new NpgsqlConnection(connString);
conn.Open();
using var createCmd = new NpgsqlCommand(
    "CREATE TABLE IF NOT EXISTS votes (id SERIAL PRIMARY KEY, vote TEXT NOT NULL);", conn);
createCmd.ExecuteNonQuery();
while (true)
{
    var vote = db.ListLeftPop("votes");
    if (!vote.IsNull)
    {
        using var cmd = new NpgsqlCommand("INSERT INTO votes(vote) VALUES (@vote)", conn);
        cmd.Parameters.AddWithValue("vote", vote.ToString());
        cmd.ExecuteNonQuery();
    }
    Thread.Sleep(1000);
}
