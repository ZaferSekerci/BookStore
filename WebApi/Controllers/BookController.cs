using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id = 1,
                Title = "Robinson Crusoe",
                GenreId = 1, //Survive
                PageCount = 365,
                PublishDate = new DateTime(1996,11,06)
            },
            new Book{
                Id = 2,
                Title = "Ölü Canlar",
                GenreId = 2, //Drama
                PageCount = 457,
                PublishDate = new DateTime(1978,06,07)
            },
            new Book{
                Id = 3,
                Title = "Avonlea",
                GenreId = 3, //Real Life Events
                PageCount = 600,
                PublishDate = new DateTime(2021,02,01)
            }
        };
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;

        }

            // [HttpGet]
            // public Book Get([FromQuery] string id)
            // {
            //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            //     return book;

            // }
    }
}