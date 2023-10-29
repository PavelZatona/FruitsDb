using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
