using FruitsDb.DAO;
using FruitsDb.DAO.Enums;
using FruitsDb.Models;
using FruitsDb.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsDb.Services.Implementation
{
    public class FruitsService : IFruitsService
    {
        private readonly IFruitsDao _fruitsDao; // readonly означает, что значение можно установить только в конструкторе
        // в остальных местах такое свойство можно только читать

        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        public FruitsService
        (
            IFruitsDao fruitsDao
        )
        {
            _fruitsDao = fruitsDao;
        }

        public IReadOnlyCollection<Fruit> GetAllFruits()
        {
            return _fruitsDao.GetAllFruits();
        }

        public string GetFruitColorName(FruitColor color)
        {
            switch (color)
            {
                case FruitColor.UnknownColor:
                    return "Неизвестный";

                case FruitColor.Red:
                    return "Красный";

                case FruitColor.Yellow:
                    return "Жёлтый";

                case FruitColor.Green:
                    return "Зелёный";

                // Специальная секция - вызывается когда ни один выбор не подошёл
                default:
                    throw new InvalidOperationException("Неизвестный цвет. Добавь его в GetFruitColorName()!");
            }
        }

        public double GetRandomWeight()
        {
            return _random.Next(50000, 250001) / 1000.0;
        }

        public void TryToAddFruit(Fruit fruit)
        {
            if (_fruitsDao.IfFruitExists(fruit.Name))
            {
                return;
            }

            _fruitsDao.AddFruit(fruit);
        }
    }
}
