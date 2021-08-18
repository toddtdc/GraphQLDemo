using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;

namespace GraphQLDemo
{
    public class BookPrintingsLoader : GroupedDataLoader<Guid, Printing>
    {
        public BookPrintingsLoader(IBatchScheduler batchScheduler, DataLoaderOptions<Guid> options = null) : base(batchScheduler, options)
        {
        }

        protected override async Task<ILookup<Guid, Printing>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var printings = await PublicationsService.GetPrintingsByBookIds(keys);
            return printings.ToLookup(b => b.BookId);
        }
    }
}
