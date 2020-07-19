using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IList<Book>> GetAll()
        {
            return await _context.Book.Include(b => b.Author).AsNoTracking().ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Book.Include(b => b.Author).AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> Create(Book newBook)
        {
            await _context.Book.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task Update(Book book)
        {
            var entity = _context.Entry(book);
            if (entity == null)
            {
                return;
            }

            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Book> Delete(int id)
        {
            var entity = await _context.Book.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return null;
            }

            _context.Book.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
