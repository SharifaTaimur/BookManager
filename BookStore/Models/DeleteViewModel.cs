using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BookStore.DAL.Repositories;

namespace BookStore.Models
{
    public class DeleteViewModel
    {
        private IBookRepository _bookRepository;
        public int Id { get; set; }

        public DeleteViewModel() { }
        public DeleteViewModel(IBookRepository bookRepository, int id)
        {
            _bookRepository = bookRepository;
            LoadData(id);
        }

        #region Data Properties

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Authers { get; set; }
        [Column("Year")]
        [Display(Name = "Publish Year")]
        public string publishYear { get; set; }
        [Column("Price")]
        [Display(Name = "Price")]
        public decimal BasePrice { get; set; }
        #endregion

        private void LoadData(int Id)
        {
            Book books = _bookRepository.GetBookByID(Id);
            Id = books.Id;
            Title = books.Title;
            Authers = books.Authers;
            publishYear = books.publishYear;
            BasePrice = books.BasePrice;
        }

        private Book CreateObjectFromModelProperties()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Authers = Authers,
                publishYear = publishYear,
                BasePrice = BasePrice
            };
        }

        public bool Save(IBookRepository _bookRepository)
        {
            Book deleting = CreateObjectFromModelProperties();
            bool deleted = _bookRepository.DeleteBook(deleting);
            return deleted;
        }
    }
}