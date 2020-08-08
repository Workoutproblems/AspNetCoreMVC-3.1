using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;


        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id) // #29
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            //return $"Book with name = {bookName} & Author = {authorName}";
            return _bookRepository.SearchBook(bookName, authorName);
        }
        // #41 ASP.Net Forms, Get method
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                //LanguageId = 2
            };

            ViewBag.Language = await _languageRepository.GetLanguages();

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "Hindi", Value = "1" },
            //    new SelectListItem(){Text = "English", Value = "2"},
            //    new SelectListItem(){Text = "Dutch", Value = "3"},
            //    new SelectListItem(){Text = "Tamil", Value = "4"},
            //    new SelectListItem(){Text = "Urdu", Value = "5"},
            //    new SelectListItem(){Text = "Chinese", Value = "6"},
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {   // #50 Post method
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }


            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "Hindi", Value = "1" },
            //    new SelectListItem(){Text = "English", Value = "2"},
            //    new SelectListItem(){Text = "Dutch", Value = "3"},
            //    new SelectListItem(){Text = "Tamil", Value = "4"},
            //    new SelectListItem(){Text = "Urdu", Value = "5"},
            //    new SelectListItem(){Text = "Chinese", Value = "6"},
            //};

            return View();
        }

        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel() { Id = 1, Text = "Hindi" },
        //        new LanguageModel() { Id = 2, Text = "English" },
        //        new LanguageModel() { Id = 3, Text = "Dutch" },
        //    };
        //}
    }
}