namespace BookStore.WebApi.Services
{
    public interface IAuthorsService
    {
        IQueryable<Models.Author> Fetch();
        Task<Models.Author> GetById(Guid id);
        Task<Models.Author> Insert(Models.AuthorInsertDto author);
        Task<Models.Author> Replace(Guid id, Models.AuthorInsertDto author);
        Task<Models.Author> Update(Guid id, Models.AuthorUpdateDto author);
        Task Delete(Guid id);
    }
}
