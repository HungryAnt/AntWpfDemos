using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo03.Models
{
    public class BookService
    {
        public BookService()
        {
        }

        public List<BookEntity> GetAllBooks()
        {
            return new List<BookEntity>()
                {
                    new BookEntity()
                        {
                            Title = "WPF编程宝典",
                            Author = "xxx"
                        },
                        new BookEntity()
                        {
                            Title = "WPF深入浅出",
                            Author = "xxx"
                        },
                        new BookEntity()
                        {
                            Title = "敏捷软件开发",
                            Author = "Uncle Bob"
                        },
                };
        }
    }
}
