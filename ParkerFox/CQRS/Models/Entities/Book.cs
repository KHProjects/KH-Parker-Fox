using CQRS.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models.Entities
{
    public class Book : AggregateRoot
    {
        public Book(Guid id) :base(id)
        {
            Register<BookCreated>(OnBookCreated);
            ApplyEvent(new BookCreated {Title = ""});
        }

        public string Title { get; set; }

        public void OnBookCreated(BookCreated bookCreated)
        {
            Title = bookCreated.Title;
        }
    }
}