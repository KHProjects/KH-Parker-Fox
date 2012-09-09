using CQRS.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS.Models.Entities;

namespace CQRS.Models.CommandHandlers
{
    public class CreateBookCommandHandler : IHandleCommand<CreateBook>
    {
        private IRepository<Book> _books;

        public CreateBookCommandHandler(IRepository<Book> books)
        {
            _books = books;
        }

        public void Handle(CreateBook command)
        {
            var book = new Book(Guid.NewGuid());
            _books.Add(book);
        }
    }
}