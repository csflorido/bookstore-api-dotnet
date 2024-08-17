using BookStore.Database;
using DbModels = BookStore.Database;
using BookStore.WebApi.Models;
using BookStore.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly BookStoreDbContext _dbContext;

        public AuthorsService(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Guid id)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(t => t.AuthorGuidKey == id);

            if (author == null)
            {
                throw new NotFoundException();
            }

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Models.Author> Fetch()
        {
            return _dbContext.Authors.AsNoTracking().Select(t => new Models.Author
            {
                Id = t.AuthorGuidKey,
                DisplayName = t.DisplayName,
                FirstName = t.FirstName,
                LastName = t.LastName,
                CreatedOn = t.CreatedTimestamp,
                LastUpdatedOn = t.LastUpdatedTimestamp
            });
        }

        public async Task<Models.Author> GetById(Guid id)
        {
            var author = await this.Fetch().FirstOrDefaultAsync(t => t.Id == id);

            if (author == null)
            {
                throw new NotFoundException();
            }

            return author;
        }

        public async Task<Models.Author> Insert(AuthorInsertDto author)
        {
            var dbmodel = new DbModels.Author();

            dbmodel.FirstName = author.FirstName;
            dbmodel.LastName = author.LastName;
            dbmodel.DisplayName = author.DisplayName;

            _dbContext.Authors.Add(dbmodel);
            await _dbContext.SaveChangesAsync();

            return new Models.Author
            {
                Id = dbmodel.AuthorGuidKey,
                FirstName = dbmodel.FirstName,
                LastName = dbmodel.LastName,
                DisplayName = dbmodel.DisplayName,
                CreatedOn = dbmodel.CreatedTimestamp,
                LastUpdatedOn = dbmodel.LastUpdatedTimestamp
            };
        }

        public async Task<Models.Author> Replace(Guid id, AuthorInsertDto author)
        {
            var dbmodel = await _dbContext.Authors.FirstOrDefaultAsync(t => t.AuthorGuidKey == id);

            if (dbmodel == null)
            {
                throw new NotFoundException();
            }

            dbmodel.FirstName = author.FirstName;
            dbmodel.LastName = author.LastName;
            dbmodel.DisplayName = author.DisplayName;
            dbmodel.LastUpdatedTimestamp = DateTime.UtcNow;

            _dbContext.Authors.Update(dbmodel);
            await _dbContext.SaveChangesAsync();

            return new Models.Author
            {
                Id = dbmodel.AuthorGuidKey,
                FirstName = dbmodel.FirstName,
                LastName = dbmodel.LastName,
                DisplayName = dbmodel.DisplayName,
                CreatedOn = dbmodel.CreatedTimestamp,
                LastUpdatedOn = dbmodel.LastUpdatedTimestamp
            };
        }

        public async Task<Models.Author> Update(Guid id, AuthorUpdateDto author)
        {
            var dbmodel = await _dbContext.Authors.FirstOrDefaultAsync(t => t.AuthorGuidKey == id);
            var isUpdated = false;

            if (dbmodel == null)
            {
                throw new NotFoundException();
            }

            if (!string.IsNullOrWhiteSpace(author.FirstName))
            {
                dbmodel.FirstName = author.FirstName;
                isUpdated = true;
            }

            if(!string.IsNullOrWhiteSpace(author.LastName))
            {
                dbmodel.LastName = author.LastName;
                isUpdated = true;
            }

            if (!string.IsNullOrWhiteSpace(author.DisplayName))
            {
                dbmodel.LastName = author.DisplayName;
                isUpdated = true;
            }

            if (isUpdated)
            {
                dbmodel.LastUpdatedTimestamp = DateTime.UtcNow;
            }

            _dbContext.Authors.Update(dbmodel);
            await _dbContext.SaveChangesAsync();

            return new Models.Author
            {
                Id = dbmodel.AuthorGuidKey,
                FirstName = dbmodel.FirstName,
                LastName = dbmodel.LastName,
                DisplayName = dbmodel.DisplayName,
                CreatedOn = dbmodel.CreatedTimestamp,
                LastUpdatedOn = dbmodel.LastUpdatedTimestamp
            };
        }
    }
}
