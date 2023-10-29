using FruitsDb.DAO;
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
