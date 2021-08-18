using HotChocolate.Types;

namespace GraphQLDemo
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(b => b.BookId).Type<IdType>();
            descriptor.Field(b => b.Title).Type<StringType>();
            descriptor.Field(b => b.PublicationDate).Type<DateTimeType>();
            descriptor.Field(b => b.ISBN).Type<StringType>();
            descriptor.Field(b => b.Author).Type<AuthorType>().ResolveWith<AuthorController>(r => r.GetAuthorForBook(default, default, default));
            descriptor.Field(b => b.Printings).Type<ListType<PrintingType>>().ResolveWith<PrintingController>(r => r.GetPrintingsForBook(default, default, default));
        }
    }
}