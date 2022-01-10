using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Robinson Crusoe",
                        GenreId = 1, //Survive
                        PageCount = 365,
                        PublishDate = new DateTime(1996, 11, 06)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Ölü Canlar",
                        GenreId = 2, //Drama
                        PageCount = 457,
                        PublishDate = new DateTime(1978, 06, 07)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Avonlea",
                        GenreId = 3, //Real Life Events
                        PageCount = 600,
                        PublishDate = new DateTime(2021, 02, 01)
                    }
            );

                context.SaveChanges();
            }
        }
    }
}