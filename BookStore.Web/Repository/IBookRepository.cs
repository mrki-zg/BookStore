using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data.Models;

namespace BookStore.Web.Repository
{
    public interface IBookRepository
    {
        Task<IList<Book>> GetAll();

        Task<Book> Get(int id);

        Task<int> Create(Book newBook);

        Task Update(Book book);

        Task<Book> Delete(int id);
    }
}