using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace GraphQLDemo
{
    public partial class AuthorController
    {
        /// <summary>
        /// Create resolvers for endpoints provided in the author controller
        /// </summary>
        /// <param name="descriptor"></param>
        public static void InitializeResolvers(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("author").Argument("authorId", a => a.Type<NonNullType<IdType>>()).ResolveWith<AuthorController>(r => r.GetAuthor(default));
            descriptor.Field("authors")
                .Argument("name", a => a.Type<StringType>())
                .Argument("authorIds", a => a.Type<ListType<IdType>>())
                .ResolveWith<AuthorController>(r => r.GetAuthors(default, default));
        }

        /// <summary>
        /// Get Author by ID
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<Author> GetAuthor(Guid authorId)
        {         
            var author = (await PublicationsService.FindAuthors(null, new[] { authorId })).FirstOrDefault();
            return author;
        }

        /// <summary>
        /// Get authors matching name and or ids list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="authorIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Author>> GetAuthors(string name = null, IEnumerable<Guid> authorIds = null)
        {
            var authors = await PublicationsService.FindAuthors(name, authorIds);
            return authors;
        }

        /// <summary>
        /// Get the Author for a Book using the BookAuthorLoader
        /// </summary>
        /// <param name="book"></param>
        /// <param name="loader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Author> GetAuthorForBook(Book book, BookAuthorLoader loader, CancellationToken cancellationToken)
        {
            var author = await loader.LoadAsync(book.BookId, cancellationToken);
            return author;
        }
    }
}
