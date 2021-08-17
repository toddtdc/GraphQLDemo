using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

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
            descriptor.Field("printings").ResolveWith<PrintingController>(r => r.GetPrintings());
        }
        
        public IEnumerable<Printing> GetPrintings()
        {
            return ExampleData.Printings;
        }

        public IEnumerable<Printing> GetPrintingsForBook(Book context)
        {
            return ExampleData.Printings.Where(p => p.BookId == context.BookId);
        }
    }
}
