using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using BookStore.DAL.Repositories;

namespace BookStore.Models
{
    public class NewBookViewModel
    {
        private IBookRepository _bookRepository;

        public NewBookViewModel(){}
        public NewBookViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        #region Data Properties
        public int Id { get; set; }
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



        #region  Save
         private Book CreateObjectFromModelProperties()
        {
            return new Book
            {
               Title=Title,
               Authers=Authers,
               publishYear=publishYear,
               BasePrice=BasePrice

            };
        }

        public bool Save(IBookRepository _bookRepository)
        {
            Book saving = CreateObjectFromModelProperties();
            bool saved = _bookRepository.InsertBook(saving);
            return saved;
        }


        #endregion

    }
}