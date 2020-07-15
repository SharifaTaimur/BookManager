using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BookStore.Models
{
    public class BookViewModel
    {
        IBookRepository _bookRepository;

        public BookViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }



         public IEnumerable<Book> ListOfBooks
        {
            get {
            return _bookRepository.GetBooks();
            }
        }
         

    }
}