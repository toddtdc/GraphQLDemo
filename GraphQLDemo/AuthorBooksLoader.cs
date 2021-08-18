using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;

namespace GraphQLDemo
{
    /// <summary>
    /// Group loader for Author's list of Books
    /// </summary>
    public class AuthorBooksLoader : GroupedDataLoader<Guid, Book>
    {
        public AuthorBooksLoader(IBatchScheduler batchScheduler, DataLoaderOptions<Guid> options = null) : base(batchScheduler, options)
        {
        }

        protected override async Task<ILookup<Guid, Book>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var books = await PublicationsService.GetBooksByAuthorIds(keys);
            return books.ToLookup(b => b.Author.AuthorId);
        }
    }
}
