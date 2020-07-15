using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookStoreConnectionString")
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}