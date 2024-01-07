﻿using Microsoft.EntityFrameworkCore;
using PatikaAkbankBookstore.Entities;

namespace PatikaAkbankBookstore.DbOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        int SaveChanges();
    }
}
