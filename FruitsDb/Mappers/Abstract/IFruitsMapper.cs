using FruitsDb.DAO;
using FruitsDb.Models;

namespace FruitsDb.Mappers.Abstract
{
    public interface IFruitsMapper
    {
        Fruit Map(FruitDbo fruit);

        FruitDbo Map(Fruit fruit);

        IReadOnlyCollection<Fruit> Map(IReadOnlyCollection<FruitDbo> fruits);

        IReadOnlyCollection<FruitDbo> Map(IReadOnlyCollection<Fruit> fruits);
    }
}
