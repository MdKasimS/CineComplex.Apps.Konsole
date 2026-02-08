using CineComplex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Repositories
{
    /// <summary>
    /// Repository interface for Movie entity operations.
    /// Abstraction layer supporting EFCore and future Dapper implementations.
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Get all movies from the database.
        /// </summary>
        /// <returns>List of all movies</returns>
        Task<List<Movie>> GetAllAsync();

        /// <summary>
        /// Get a movie by its ID.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Movie object or null if not found</returns>
        Task<Movie> GetByIdAsync(int id);

        /// <summary>
        /// Get a movie by its cinema code.
        /// </summary>
        /// <param name="cinemaCode">Cinema code</param>
        /// <returns>Movie object or null if not found</returns>
        Task<Movie> GetByCinemaCodeAsync(string cinemaCode);

        /// <summary>
        /// Search movies by name.
        /// </summary>
        /// <param name="movieName">Movie name or partial name</param>
        /// <returns>List of matching movies</returns>
        Task<List<Movie>> SearchByNameAsync(string movieName);

        /// <summary>
        /// Search movies by genre.
        /// </summary>
        /// <param name="genre">Genre to search</param>
        /// <returns>List of movies with matching genre</returns>
        Task<List<Movie>> SearchByGenreAsync(string genre);

        /// <summary>
        /// Search movies by language.
        /// </summary>
        /// <param name="language">Language to search</param>
        /// <returns>List of movies with matching language</returns>
        Task<List<Movie>> SearchByLanguageAsync(string language);

        /// <summary>
        /// Get movies with pagination.
        /// </summary>
        /// <param name="pageNumber">Page number (1-based)</param>
        /// <param name="pageSize">Number of records per page</param>
        /// <returns>Paginated list of movies</returns>
        Task<List<Movie>> GetPaginatedAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Add a new movie to the database.
        /// </summary>
        /// <param name="movie">Movie object to add</param>
        /// <returns>Added movie object with ID</returns>
        Task<Movie> AddAsync(Movie movie);

        /// <summary>
        /// Add multiple movies to the database.
        /// </summary>
        /// <param name="movies">List of movies to add</param>
        /// <returns>List of added movies with IDs</returns>
        Task<List<Movie>> AddBulkAsync(List<Movie> movies);

        /// <summary>
        /// Update an existing movie.
        /// </summary>
        /// <param name="movie">Movie object with updated data</param>
        /// <returns>Updated movie object</returns>
        Task<Movie> UpdateAsync(Movie movie);

        /// <summary>
        /// Update multiple movies.
        /// </summary>
        /// <param name="movies">List of movies to update</param>
        /// <returns>List of updated movies</returns>
        Task<List<Movie>> UpdateBulkAsync(List<Movie> movies);

        /// <summary>
        /// Delete a movie by its ID.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>True if successful, false if not found</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Delete a movie object.
        /// </summary>
        /// <param name="movie">Movie object to delete</param>
        /// <returns>True if successful</returns>
        Task<bool> DeleteAsync(Movie movie);

        /// <summary>
        /// Delete multiple movies by IDs.
        /// </summary>
        /// <param name="ids">List of movie IDs</param>
        /// <returns>Number of deleted movies</returns>
        Task<int> DeleteBulkAsync(List<int> ids);

        /// <summary>
        /// Check if a movie exists by ID.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>True if exists, false otherwise</returns>
        Task<bool> ExistsAsync(int id);

        /// <summary>
        /// Get total count of movies.
        /// </summary>
        /// <returns>Total number of movies</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// Get movies by director name.
        /// </summary>
        /// <param name="directorName">Director name</param>
        /// <returns>List of movies by the director</returns>
        Task<List<Movie>> GetByDirectorAsync(string directorName);

        /// <summary>
        /// Get movies by producer name.
        /// </summary>
        /// <param name="producerName">Producer name</param>
        /// <returns>List of movies by the producer</returns>
        Task<List<Movie>> GetByProducerAsync(string producerName);

        /// <summary>
        /// Get movies with their associated shows.
        /// </summary>
        /// <returns>List of movies with shows included</returns>
        Task<List<Movie>> GetMoviesWithShowsAsync();

        /// <summary>
        /// Get a specific movie with its associated shows.
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Movie with shows included</returns>
        Task<Movie> GetMovieWithShowsAsync(int id);
    }
}
