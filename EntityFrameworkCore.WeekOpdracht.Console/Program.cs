using EntityFrameworkCore.WeekOpdracht.Business;
using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;

namespace EntityFrameworkCore.WeekOpdracht.Console
{
    class Program
    {
        private static IUserService userService;
        private static IMessageService messageService;
        private static ILogger logger;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                userService = serviceProvider.GetRequiredService<IUserService>();
                messageService = serviceProvider.GetRequiredService<IMessageService>();
                logger = serviceProvider.GetRequiredService<ILogger>();
            }

            logger.write("Deleting old stuff");
            System.Console.WriteLine("Deleting old stuff");
            DeleteAll();

            logger.write("Creating new user");
            System.Console.WriteLine("Creating new user");
            var user = CreateUser();

            logger.write("Creating a message from the new user");
            System.Console.WriteLine("Creating a message from the new user");
            CreateMessage(user);

            logger.write("Creating a message from the new user");
            System.Console.WriteLine("Creating a message from the new user");
            System.Console.ReadKey();
        }

        private static void CreateMessage(User user)
        {
            var message = messageService.Add(new Business.Entities.Message
            {
                Content = "Test bericht",
                SenderId = user.Id,
                Title = $"Nieuw test bericht van {user.Lastname}"
            });

            logger.write($"    Message with title {message.Title} created. New ID is {message.Id}");
            System.Console.WriteLine($"    Message with title {message.Title} created. New ID is {message.Id}");
            Thread.Sleep(2500);
        }

        private static User CreateUser()
        {
            var user = userService.Add(new Business.Entities.User
            {
                Email = "Test@test.nl",
                Lastname = "De Tester",
                Name = "Test"
            });

            logger.write($"    User with name {user.Name} created. New ID is {user.Id}");
            System.Console.WriteLine($"    User with name {user.Name} created. New ID is {user.Id}");
            Thread.Sleep(2500);

            return user;
        }
        private static void DeleteAll()
        {
            foreach (var item in userService.GetAll().ToList())
                userService.Delete(item.Id);

            foreach (var item in messageService.GetAll().ToList())
                messageService.Delete(item.Id);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ILogger, ConsoleLogger>();
        }
    }
}
