using HotChocolate.Types;

namespace GraphQLDemo
{
    public class PrintingType : ObjectType<Printing>
    {
        protected override void Configure(IObjectTypeDescriptor<Printing> descriptor)
        {
            descriptor.Field(f => f.BookId).Type<IdType>();
            descriptor.Field(f => f.PrintingDate).Type<DateTimeType>();
            descriptor.Field(f => f.RunSize).Type<IntType>();
        }
    }
}
