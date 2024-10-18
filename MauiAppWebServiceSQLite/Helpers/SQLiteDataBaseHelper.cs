using SQLite;
using MauiAppWebServiceSQLite.Models;

namespace MauiAppWebServiceSQLite.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        /*
            * O MESMO ERRO DE CS0050; 
        */
        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Tempo>().Wait();
        }

        public Task<int> Insert (Tempo t)
        {
            return _conn.InsertAsync(t);
        }

        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().ToListAsync();
        }

        public Task<List<Tempo>> Search(string query) {
            string sql = $"SELECT * Tempo WHERE srcDate Like %{query}%";
            return _conn.QueryAsync<Tempo>(sql);
        }
    }
}
