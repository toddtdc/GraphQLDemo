using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo
{
    public class BookController
    {
        /// <summary>
        /// Create resolvers for endpoints provided in the book controller
        /// </summary>
        /// <param name="descriptor"></param>
        public static void InitializeResolvers(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("book").Argument("bookId", a => a.Type<NonNullType<IdType>>()).ResolveWith<BookController>(r => r.GetBook(default));
            descriptor.Field("books")
                .Argument("authorId", a => a.Type<IdType>())
                .Argument("bookIds", a => a.Type<ListType<IdType>>())
                .ResolveWith<BookController>(r => r.GetBooks(default, default));
        }

        public Book GetBook(Guid bookId)
        {
            return ExampleData.Books.FirstOrDefault(b => b.BookId == bookId);
        }
       
        public IEnumerable<Book> GetBooks(Guid authorId, List<Guid> bookIds = null)
        {
            if (authorId.Equals(Guid.Empty) && !(bookIds?.Count > 0))
            {
                return ExampleData.Books;
            }

            if (!authorId.Equals(Guid.Empty))
            {
                var authorBookIds = ExampleData.BookAuthors.Where(ba => ba.Value == authorId).Select(ba => ba.Key).ToList();
                if (bookIds?.Count > 0)
                {
                    authorBookIds.RemoveAll(ab => !bookIds.Contains(ab));
                }
                bookIds = authorBookIds;
                
            }
            return ExampleData.Books.Where(b => bookIds.Contains(b.BookId));
        }

        public IEnumerable<Book> GetBooksForAuthor(Author author = null)
        {
            return GetBooks(author.AuthorId);
        }
    }
}
