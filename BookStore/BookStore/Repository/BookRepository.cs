using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        // using dependency injection to initialize #46
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl

            };
            //_context.Books.Add(newBook);
            //_context.SaveChanges(); #47
            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            // #48 get data from DB, convert Books data to BookModel
            //var allbooks = await _context.Books.ToListAsync();
            //var books = new List<BookModel>();
            //if (allbooks?.Any() == true)
            //{
            //    foreach (var book in allbooks)
            //    {   
            //        books.Add(new BookModel()
            //        {
            //            Author = book.Author,
            //            Category = book.Category,
            //            Description = book.Description,
            //            Id = book.Id,
            //            LanguageId = book.LanguageId,
            //            Language = book.Language.Name,
            //            Title = book.Title,
            //            TotalPages = book.TotalPages
            //        });
            //    }
            //}
            //return books;
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                 .Select(book => new BookModel()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Description = book.Description,
                     Id = book.Id,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     Title = book.Title,
                     TotalPages = book.TotalPages,
                     CoverImageUrl = book.CoverImageUrl
                 }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel(){Id = 1, Title="MVC", Author="Johnny", Description="This is the description for MVC", Category="Programming", Language="English", TotalPages=124},
        //        new BookModel(){Id = 2, Title="C#", Author="Sally",   Description="This is the description for C#", Category="Framework", Language="English", TotalPages=360},
        //        new BookModel(){Id = 3, Title="C++", Author="Brian",  Description="This is the description for C++", Category="Programming", Language="English", TotalPages=124},
        //        new BookModel(){Id = 4, Title="Python", Author="Peter", Description="This is the description for Python", Category="Programming", Language="English", TotalPages=124},
        //        new BookModel(){Id = 5, Title="Java", Author="Sandy", Description="This is the description for Java", Category="Programming", Language="English", TotalPages=124},
        //        new BookModel(){Id = 6, Title="Azure", Author="Jane", Description="This is the description for Azure", Category="Programming", Language="English", TotalPages=124}
        //    };
        
        //}
    }
}
