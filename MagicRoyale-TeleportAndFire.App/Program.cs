using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MagicRoyale_TeleportAndFire.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = services.GetRequiredService<MagicRoyaleDbContext>();
                User user1 = new User { Name = "Tom", Age = 32 };
                User user2 = new User { Name = "Avon", Age = 19 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты добавлены в БД и сохранены");

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов: ");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }

            }
            Console.Read();

            //CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
