using FruitsDb.DAO;
using FruitsDb.Mappers.Abstract;
using FruitsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsDb.Mappers.Implemntations
{
    public class FruitsMapper : IFruitsMapper
    {
        public Fruit Map(FruitDbo fruit)
        {
            if (fruit == null)
            {
                return null;
            }

            return new Fruit()
            {
                Id = fruit.Id,
                Name = fruit.Name,
                Weight = fruit.Weight
            };
        }

        public FruitDbo Map(Fruit fruit)
        {
            if (fruit == null)
            {
                return null;
            }

            return new FruitDbo()
            {
                Id = fruit.Id,
                Name = fruit.Name,
                Weight = fruit.Weight
            };
        }

        public IReadOnlyCollection<Fruit> Map(IReadOnlyCollection<FruitDbo> fruits)
        {
            if (fruits == null)
            {
                return null;
            }

            return fruits
                .Select(f => Map(f))
                .ToList();
        }

        public IReadOnlyCollection<FruitDbo> Map(IReadOnlyCollection<Fruit> fruits)
        {
            if (fruits == null)
            {
                return null;
            }

            return fruits
                .Select(f => Map(f))
                .ToList();
        }
    }
}
