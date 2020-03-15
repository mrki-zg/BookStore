using System;
using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
