using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo
{

    /// <summary>
    ///  This is root query controller
    /// </summary>
    [GraphQLName("PublicationsService")]
    public class QueryController : ObjectType
    {
        /// <summary>
        ///  Including other controllers into the graph
        /// </summary>
        /// <param name="descriptor"></param>
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            AuthorController.InitializeResolvers(descriptor);
            BookController.InitializeResolvers(descriptor);
            PrintingController.InitializeResolvers(descriptor);
        }
    }
}
