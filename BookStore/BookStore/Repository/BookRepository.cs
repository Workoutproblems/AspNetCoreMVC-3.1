﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains( title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title="MVC", Author="Johnny", Description="This is the description for MVC", Category="Programming", Language="English", TotalPages=124},
                new BookModel(){Id = 2, Title="C#", Author="Sally",   Description="This is the description for C#", Category="Framework", Language="English", TotalPages=360},
                new BookModel(){Id = 3, Title="C++", Author="Brian",  Description="This is the description for C++", Category="Programming", Language="English", TotalPages=124},
                new BookModel(){Id = 4, Title="Python", Author="Peter", Description="This is the description for Python", Category="Programming", Language="English", TotalPages=124},
                new BookModel(){Id = 5, Title="Java", Author="Sandy", Description="This is the description for Java", Category="Programming", Language="English", TotalPages=124},
                new BookModel(){Id = 6, Title="Azure", Author="Jane", Description="This is the description for Azure", Category="Programming", Language="English", TotalPages=124}
            };
        
        }
    }
}
