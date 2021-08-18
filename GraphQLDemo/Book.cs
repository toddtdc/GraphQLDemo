using HotChocolate;
using System;
using System.Collections.Generic;

namespace GraphQLDemo
{
    public class Book
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        [GraphQLName("isbn")]
        public string ISBN { get; set; }

        public Author Author { get; set; }

        public IEnumerable<Printing> Printings { get; set; }
    }
}
