using Microsoft.EntityFrameworkCore;

namespace FruitsDb.DAO
{
    public class MainDbContext : DbContext
    {
        private string _dbPath;

        public MainDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = System.IO.Path.Join(path, "fruits.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={_dbPath}");
        }

        /// <summary>
        /// Fruits
        /// </summary>
        public DbSet<FruitDbo> Fruits { get; set; }
    }
}