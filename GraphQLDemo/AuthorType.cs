using HotChocolate.Types;

namespace GraphQLDemo
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.AuthorId).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Books).Type<ListType<BookType>>().ResolveWith<BookController>(t => t.GetBooksForAuthor(default));
        }
    }
}
