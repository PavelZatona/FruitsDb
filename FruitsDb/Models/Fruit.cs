using FruitsDb.DAO.Enums;

namespace FruitsDb.Models
{
    /// <summary>
    /// Модель фрукта
    /// </summary>
    public class Fruit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public FruitColor Color { get; set; }
    }
}
