using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDemo
{
    public class PrintingController 
    {
        /// <summary>
        /// Create resolvers for endpoints provided in the printings controller
        /// </summary>
        /// <param name="descriptor"></param>
        public static void InitializeResolvers(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("printings").Argument("bookId", a=>a.Type<IdType>()).ResolveWith<PrintingController>(r => r.GetPrintings(default));
        }
        
        /// <summary>
        /// Get printings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Printing>> GetPrintings(Guid? bookId)
        {
            Guid[] bookIds = bookId == null ? null : new[] { bookId.Value };
            var printings = await PublicationsService.GetPrintingsByBookIds(bookIds);
            return printings;
        }

        /// <summary>
        /// Get the printings for a book using the BookPrintingsLoader
        /// </summary>
        /// <param name="book"></param>
        /// <param name="loader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Printing>> GetPrintingsForBook(Book book, BookPrintingsLoader loader, CancellationToken cancellationToken)
        {
            return await loader.LoadAsync(book.BookId, cancellationToken);
        }
    }
}
