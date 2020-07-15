using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;
        public BookRepository(BookContext bookContext)
        {
            this._context = bookContext;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }
       
        public bool InsertBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteBook(Book book)
        {
            /* _context.Books.Remove(book);
             _context.SaveChanges();
             return true; */
            _context.Entry(book).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public bool UpdateBook(Book book)
        {    //O
            //_context.Entry(book).State = EntityState.Modified;
            //old code
            // _context.ContractProjectPayment.Add(item);
            // _context.SaveChanges();
            // return true;
            _context.Entry(book).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        /*public void InsertBook(Book book)
         {
             _context.Books.Add(book);
         } 
        public bool DeleteBook(int bookID)
        {
            Book book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }*/



        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
