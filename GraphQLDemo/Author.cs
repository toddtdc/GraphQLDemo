using System;
using System.Collections.Generic;

namespace GraphQLDemo
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
