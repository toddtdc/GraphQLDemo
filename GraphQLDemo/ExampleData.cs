using System;
using System.Collections.Generic;

namespace GraphQLDemo
{
    public static class ExampleData
    {
        public readonly static List<Author> Authors = new()
        {
            new Author
            {
                AuthorId = new Guid("AA042B03-DDA9-4906-A1AF-A7345155FB04"),
                Name = "Jon Skeet",
            },
            new Author
            {
                AuthorId = new Guid("89709F62-1E7B-4924-909E-51FB0FD12E76"),
                Name = "Joan Doe"
            },
            new Author
            {
                AuthorId = new Guid("7BDF4B18-5D30-49D0-A628-967045B97B72"),
                Name = "Jon Doe"
            }
        };

        public readonly static List<Printing> Printings = new() 
        {
            new Printing
            {
                BookId = new Guid("621F5205-A5F0-414D-BF14-93AA5C58FC80"),
                PrintingDate = DateTime.Parse("2010-10-10"),
                RunSize = 1000
            },
            new Printing
            {
                BookId =new Guid("621F5205-A5F0-414D-BF14-93AA5C58FC80"),
                PrintingDate = DateTime.Parse("2012-12-12"),
                RunSize = 20000
            },
            new Printing
            {
                BookId = new Guid("1BE3DF91-4CE6-4373-84FE-A3C65113065B"),
                PrintingDate = DateTime.Parse("2012-02-02"),
                RunSize = 2000
            },
            new Printing
            {
                BookId = new Guid("C788F797-027B-41B0-B335-F474DB897C67"),
                PrintingDate = DateTime.Parse("2013-03-03"),
                RunSize = 3000
            },
            new Printing
            {
                BookId = new Guid("621F5205-A5F0-414D-BF14-93AA5C58FC80"),
                PrintingDate = DateTime.Parse("2014-04-04"),
                RunSize = 4000
            },
            new Printing
            {
                BookId = new Guid("AEBAFC6C-35C3-46EB-B4F9-A6838B2AA8DD"),
                PrintingDate = DateTime.Parse("2015-05-05"),
                RunSize = 5000
            },
            new Printing
            {
                BookId = new Guid("AEBAFC6C-35C3-46EB-B4F9-A6838B2AA8DD"),
                PrintingDate = DateTime.Parse("2015-05-25"),
                RunSize = 25000
            }
        };            

        public readonly static List<Book> Books = new()
        {
            new Book
            {
                BookId = new Guid("621F5205-A5F0-414D-BF14-93AA5C58FC80"),
                Title = "C# in depth.",
                PublicationDate = DateTime.Parse("2001-01-01"),
                ISBN = "987-6-45321-01-1"
            },
            new Book
            {
                BookId = new Guid("1BE3DF91-4CE6-4373-84FE-A3C65113065B"),
                Title = "Book 2",
                PublicationDate = DateTime.Parse("2002-02-02"),
                ISBN = "987-6-45321-02-2"
            },
            new Book
            {
                BookId = new Guid("C788F797-027B-41B0-B335-F474DB897C67"),
                PublicationDate = DateTime.Parse("2003-03-03"),
                Title = "Book 3",
                ISBN = "987-6-45321-03-3"
            },
            new Book
            {
                BookId = new Guid("AEBAFC6C-35C3-46EB-B4F9-A6838B2AA8DD"),
                Title = "Beyond C# in depth.",
                ISBN = "987-6-45321-12-1",
                PublicationDate = DateTime.Parse("2015-12-12")
            }
        };

        public readonly static Dictionary<Guid, Guid> BookAuthors = new()
        {
            { new Guid("621F5205-A5F0-414D-BF14-93AA5C58FC80"), new Guid("7BDF4B18-5D30-49D0-A628-967045B97B72") },
            { new Guid("1BE3DF91-4CE6-4373-84FE-A3C65113065B"), new Guid("7BDF4B18-5D30-49D0-A628-967045B97B72") },
            { new Guid("C788F797-027B-41B0-B335-F474DB897C67"), new Guid("89709F62-1E7B-4924-909E-51FB0FD12E76") },
            { new Guid("AEBAFC6C-35C3-46EB-B4F9-A6838B2AA8DD"), new Guid("AA042B03-DDA9-4906-A1AF-A7345155FB04") },
        };
    }
}
