using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
   public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);
        bool InsertBook(Book book);
        //bool DeleteBook(int bookID);
        bool DeleteBook(Book book);
        bool UpdateBook(Book book);
        void Save();
    }
}
