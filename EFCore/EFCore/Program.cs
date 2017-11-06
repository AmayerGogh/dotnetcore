using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (DataDbContxt ctx=new DataDbContxt())
            //{
            //    Person p = new Person() { Name = "zz", Age = 11, Gender = false };
            //    ctx.Add(p);
            //    ctx.SaveChanges();
            //}

            using (DataDbContxt ctx=new DataDbContxt())
            {
                var author = ctx.Books.Include(e => e.Author).First();
                Console.WriteLine(author.Author.AuthorName);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
