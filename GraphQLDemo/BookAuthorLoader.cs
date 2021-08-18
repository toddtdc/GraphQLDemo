using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;

namespace GraphQLDemo
{
    public class BookAuthorLoader : BatchDataLoader<Guid, Author>
    {
        public BookAuthorLoader(IBatchScheduler batchScheduler, DataLoaderOptions<Guid> options = null) : base(batchScheduler, options)
        {
        }

        protected override async Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var authors = await PublicationsService.GetAuthorsForBookIds(keys);
            return authors;
        }
    }
}
