using FruitsDb.Mappers.Abstract;
using FruitsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsDb.DAO
{
    public class FruitsDao : IFruitsDao
    {
        private readonly IFruitsMapper _fruitsMapper;

        private MainDbContext _dbContext = new MainDbContext();

        public FruitsDao
        (
            IFruitsMapper fruitsMapper
        )
        {
            _fruitsMapper = fruitsMapper;
        }

        public void AddFruit(Fruit fruitToAdd)
        {
            var fruitDbo = _fruitsMapper.Map(fruitToAdd);

            _dbContext.Fruits.Add(fruitDbo); // Тут мы говорим "сейчас мы будем вставлять строку noteDbo в базу"
            _dbContext.SaveChanges(); // Тут мы собственно сохраняем данные
        }

        public IReadOnlyCollection<Fruit> GetAllFruits()
        {
            var fruits = _dbContext
                .Fruits
                .OrderBy(f => f.Name)
                .ToList();

            return _fruitsMapper.Map(fruits);
        }

        public bool IfFruitExists(string name)
        {
            return _dbContext
                .Fruits
                .Any(f => f.Name == name);
        }
    }
}
