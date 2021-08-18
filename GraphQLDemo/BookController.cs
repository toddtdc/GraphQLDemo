using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get book by Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<Book> GetBook(Guid bookId)
        {
            var book = (await PublicationsService.FindBooks(null, new[] { bookId })).FirstOrDefault();
            return book;
        }
       
        /// <summary>
        /// Get books by authorId and/or list of bookIds
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="bookIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetBooks(Guid? authorId=null, IEnumerable<Guid> bookIds = null)
        {
            var books = await PublicationsService.FindBooks(authorId, bookIds);
            return books;
        }

        /// <summary>
        /// Get the books for author via the AuthorBooksLoader
        /// </summary>
        /// <param name="author"></param>
        /// <param name="loader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Book[]> GetBooksForAuthor(Author author, AuthorBooksLoader loader, CancellationToken cancellationToken)
        {
            var books = await loader.LoadAsync(author.AuthorId, cancellationToken);
            return books;
        }
    }
}
