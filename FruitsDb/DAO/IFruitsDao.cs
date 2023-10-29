using FruitsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsDb.DAO
{
    public interface IFruitsDao
    {
        /// <summary>
        /// Получить список всех фруктов
        /// </summary>
        IReadOnlyCollection<Fruit> GetAllFruits();

        /// <summary>
        /// Добавляем фрукт в базу
        /// </summary>
        void AddFruit(Fruit fruitToAdd);

        /// <summary>
        /// Проверка на то существует ли фрукт в базе
        /// </summary>
        bool IfFruitExists(string name);
    }
}
