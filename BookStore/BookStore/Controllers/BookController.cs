using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult GetAllBooks() 
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public ViewResult GetBook(int id) // #29
        {
            dynamic data = new ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Johnny ExpandoObject";
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            //return $"Book with name = {bookName} & Author = {authorName}";
            return _bookRepository.SearchBook(bookName, authorName);
        }
        // #41 ASP.Net Forms
        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBook(BookModel mookModel)
        {
            return View();
        }
    }
}