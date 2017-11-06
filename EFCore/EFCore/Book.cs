using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class Book
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public Author Author { get; set; }
        public long AuthorId { get; set; }
    }
}
