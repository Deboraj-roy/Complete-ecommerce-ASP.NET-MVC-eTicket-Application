using eTicket.Data.Base;
using eTicket.Data.ViewModels;
using eTicket.Models;

namespace eTicket.Data.Services.IServices
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValuesAsync();
        Task AddNewMovieAsync(NewMovieVM newMovie);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
