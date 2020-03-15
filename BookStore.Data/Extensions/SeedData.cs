using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BookStore.Data.Models;

namespace BookStore.Data.Extensions
{
    public static class SeedData
    {
        public static void SeedBooks(BookStoreContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (!ctx.Author.Any())
            {
                ctx.Author.Add(new Author
                {
                    Id = 0,
                    FirstName = "Stephen",
                    LastName = "King"
                });

                ctx.Author.Add(new Author
                {
                    Id = 1,
                    FirstName = "Dan",
                    LastName = "Brown"
                });
            }

            if (!ctx.Book.Any())
            {
                ctx.Book.Add(new Book
                {
                    Id = 0,
                    Title = "It",
                    AuthorId = 0,
                    Price = 20,
                    Summary = "Very scary book about adults coming back to their hometown, where a terrible monster from their childhood awaits them."
                });

                ctx.Book.Add(new Book
                {
                    Id = 1,
                    Title = "The Dome",
                    AuthorId = 0,
                    Price = 16,
                    Summary = "Suddenly a small town in Derry gets covered by a dome, trapping people inside. Why is the dome there and can it be removed?"
                });

                ctx.Book.Add(new Book
                {
                    Id = 2,
                    Title = "The Sacrileg",
                    AuthorId = 1,
                    Price = 25,
                    Summary = "A mistery book about finding the holy grail and uncovering a plot to silence the people in search of it."
                });
            }

            ctx.SaveChanges();
        }
    }
}
