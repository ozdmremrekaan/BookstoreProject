using PatikaAkbankBookstore.DbOperations;
using PatikaAkbankBookstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {

            context.Authors.AddRange(
                    new Author { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1975, 05, 12) },
                    new Author { FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1980, 08, 25) },
                    new Author { FirstName = "Alice", LastName = "Smith", BirthDate = new DateTime(1968, 11, 03) }
                );
        }
    }
}
