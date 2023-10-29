using FruitsDb.DAO.Enums;
using FruitsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsDb.Services.Abstract
{
    public interface IFruitsService
    {
        /// <summary>
        /// Get all fruits from DB
        /// </summary>
        /// <returns>Readonly collection with fruits</returns>
        IReadOnlyCollection<Fruit> GetAllFruits();

        /// <summary>
        /// Try to add fruit. If fruit alredy exist, then do nothing
        /// </summary>
        /// <param name="fruit">Fruit to add</param>
        void TryToAddFruit(Fruit fruit);

        /// <summary>
        /// Get human-readable color name
        /// </summary>
        string GetFruitColorName(FruitColor color);
    }
}
