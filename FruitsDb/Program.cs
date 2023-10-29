using FruitsDb.DAO;
using FruitsDb.DAO.Enums;
using FruitsDb.Mappers.Abstract;
using FruitsDb.Mappers.Implemntations;
using FruitsDb.Models;
using FruitsDb.Services.Abstract;
using FruitsDb.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FruitsDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DI setup

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(args);

            // Тут связываем интерфейсы с реализацией
            hostApplicationBuilder.Services.AddSingleton<IFruitsMapper, FruitsMapper>(); // Теперь DI знает, что на место
            // IFruitsMapper надо подсовывать FruitsMapper

            hostApplicationBuilder.Services.AddSingleton<IFruitsDao, FruitsDao>();

            hostApplicationBuilder.Services.AddSingleton<IFruitsService, FruitsService>();

            using IHost host = hostApplicationBuilder.Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider diProvider = serviceScope.ServiceProvider;

            #endregion

            // Единственное, с чем мы имеем право работать на верхнем уровне - это сервис. Мы не должны ничего знать
            // о базах, мапперах и т.п. - они живут отдельно
            var fruitsService = diProvider.GetService<IFruitsService>();

            // Вставляем фрукты
            fruitsService.TryToAddFruit(new Fruit() { Name = "Апельсин", Weight = 250.0, Color = FruitColor.Red });
            fruitsService.TryToAddFruit(new Fruit() { Name = "Лимон", Weight = 150, Color= FruitColor.Yellow });
            fruitsService.TryToAddFruit(new Fruit() { Name = "Мандарин", Weight = 100, Color = FruitColor.Green });

            // Распечатываем фрукты
            var fruits = fruitsService.GetAllFruits();

            foreach (var fruit in fruits)
            {
                Console.WriteLine($"ID: {fruit.Id}, Название: {fruit.Name}, Вес: {fruit.Weight}, Цвет: { fruitsService.GetFruitColorName(fruit.Color) }");
            }

            Console.ReadLine();
        }
    }
}