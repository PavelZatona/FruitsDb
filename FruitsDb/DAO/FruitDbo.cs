using System.ComponentModel.DataAnnotations;

namespace FruitsDb.DAO
{
    /// <summary>
    /// Запись в таблице фруктов
    /// </summary>
    public class FruitDbo
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }
    }
}
