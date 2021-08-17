using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate.Types;

namespace GraphQLDemo
{
    public class AuthorController
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

        public Author GetAuthor(Guid authorId)
        {
            return ExampleData.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        }


        public IEnumerable<Author> GetAuthors(string name, List<Guid> authorIds=null)
        {

            if (authorIds == null) {
                authorIds = new List<Guid>();
            }

            if (string.IsNullOrWhiteSpace(name) && !authorIds.Any())
            {
                return ExampleData.Authors;
            }

            return ExampleData.Authors.Where(a => 
                (string.IsNullOrWhiteSpace(name) || a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)) &&
                (!authorIds.Any() || authorIds.Contains(a.AuthorId)));
        }

        public Author GetAuthorForBook(Book book)
        {
            if (ExampleData.BookAuthors.TryGetValue(book.BookId, out var authorId))
            {
                var author = ExampleData.Authors.FirstOrDefault(a => a.AuthorId == authorId);
                return author;
            }
            return null;
        }
    }
}
