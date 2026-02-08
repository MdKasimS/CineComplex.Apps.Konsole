using CineComplex.Classes.Base;
using CineComplex.Classes.SQL;
using CineComplex.Models;
using Microsoft.EntityFrameworkCore;

namespace CineComplex.Repositories
{
    /// <summary>
    /// EFCore implementation of the Movie repository.
    /// Can be swapped for Dapper implementation maintaining the same interface.
    /// </summary>
    public class MovieRepository : ABaseSingleton<MovieRepository>, IMovieRepository
    {
        /// <summary>
        /// Protected constructor to prevent direct instantiation (singleton pattern).
        /// </summary>
        public MovieRepository() { }

        /// <summary>
        /// Gets the database context from SQLInteraction singleton.
        /// </summary>
        private CineComplexDb Context => SQLInteraction.Db;

        /// <summary>
        /// Get all movies from the database.
        /// </summary>
        public async Task<List<Movie>> GetAllAsync()
        {
            try
            {
                return await Context.Movies.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all movies: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get a movie by its ID.
        /// </summary>
        public async Task<Movie> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Movie ID must be greater than 0.");

                return await Context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movie with ID {id}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get a movie by its cinema code.
        /// </summary>
        public async Task<Movie> GetByCinemaCodeAsync(string cinemaCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cinemaCode))
                    throw new ArgumentException("Cinema code cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.CinemaCode == cinemaCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movie with cinema code {cinemaCode}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Search movies by name.
        /// </summary>
        public async Task<List<Movie>> SearchByNameAsync(string movieName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(movieName))
                    throw new ArgumentException("Movie name cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .Where(m => m.MovieName.Contains(movieName))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching movies by name '{movieName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Search movies by genre.
        /// </summary>
        public async Task<List<Movie>> SearchByGenreAsync(string genre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(genre))
                    throw new ArgumentException("Genre cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .Where(m => m.Genre == genre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching movies by genre '{genre}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Search movies by language.
        /// </summary>
        public async Task<List<Movie>> SearchByLanguageAsync(string language)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(language))
                    throw new ArgumentException("Language cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .Where(m => m.Language == language)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching movies by language '{language}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get movies with pagination.
        /// </summary>
        public async Task<List<Movie>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber <= 0)
                    throw new ArgumentException("Page number must be greater than 0.");
                if (pageSize <= 0)
                    throw new ArgumentException("Page size must be greater than 0.");

                return await Context.Movies
                    .AsNoTracking()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving paginated movies (page {pageNumber}, size {pageSize}): {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Add a new movie to the database.
        /// </summary>
        public async Task<Movie> AddAsync(Movie movie)
        {
            try
            {
                if (movie == null)
                    throw new ArgumentNullException(nameof(movie));

                // Validate required fields
                if (string.IsNullOrWhiteSpace(movie.MovieName))
                    throw new ArgumentException("Movie name is required.");
                if (string.IsNullOrWhiteSpace(movie.CinemaCode))
                    throw new ArgumentException("Cinema code is required.");

                Context.Movies.Add(movie);
                await Context.SaveChangesAsync();

                return movie;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while adding movie: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding movie: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Add multiple movies to the database.
        /// </summary>
        public async Task<List<Movie>> AddBulkAsync(List<Movie> movies)
        {
            try
            {
                if (movies == null || movies.Count == 0)
                    throw new ArgumentException("Movie list cannot be null or empty.");

                Context.Movies.AddRange(movies);
                await Context.SaveChangesAsync();

                return movies;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while bulk adding movies: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error bulk adding movies: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Update an existing movie.
        /// </summary>
        public async Task<Movie> UpdateAsync(Movie movie)
        {
            try
            {
                if (movie == null)
                    throw new ArgumentNullException(nameof(movie));

                if (movie.Id <= 0)
                    throw new ArgumentException("Movie ID must be valid.");

                var existingMovie = await Context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
                if (existingMovie == null)
                    throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");

                // Update properties
                Context.Entry(existingMovie).CurrentValues.SetValues(movie);
                await Context.SaveChangesAsync();

                return existingMovie;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while updating movie: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating movie: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Update multiple movies.
        /// </summary>
        public async Task<List<Movie>> UpdateBulkAsync(List<Movie> movies)
        {
            try
            {
                if (movies == null || movies.Count == 0)
                    throw new ArgumentException("Movie list cannot be null or empty.");

                foreach (var movie in movies)
                {
                    var existingMovie = await Context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
                    if (existingMovie != null)
                    {
                        Context.Entry(existingMovie).CurrentValues.SetValues(movie);
                    }
                }

                await Context.SaveChangesAsync();
                return movies;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while bulk updating movies: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error bulk updating movies: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Delete a movie by its ID.
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Movie ID must be greater than 0.");

                var movie = await Context.Movies.FirstOrDefaultAsync(m => m.Id == id);
                if (movie == null)
                    return false;

                Context.Movies.Remove(movie);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while deleting movie: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting movie with ID {id}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Delete a movie object.
        /// </summary>
        public async Task<bool> DeleteAsync(Movie movie)
        {
            try
            {
                if (movie == null)
                    throw new ArgumentNullException(nameof(movie));

                var movieToDelete = await Context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
                if (movieToDelete == null)
                    return false;

                Context.Movies.Remove(movieToDelete);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while deleting movie: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting movie: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Delete multiple movies by IDs.
        /// </summary>
        public async Task<int> DeleteBulkAsync(List<int> ids)
        {
            try
            {
                if (ids == null || ids.Count == 0)
                    throw new ArgumentException("ID list cannot be null or empty.");

                var moviesToDelete = await Context.Movies
                    .Where(m => ids.Contains(m.Id))
                    .ToListAsync();

                if (moviesToDelete.Count == 0)
                    return 0;

                Context.Movies.RemoveRange(moviesToDelete);
                await Context.SaveChangesAsync();

                return moviesToDelete.Count;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while bulk deleting movies: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error bulk deleting movies: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Check if a movie exists by ID.
        /// </summary>
        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Movie ID must be greater than 0.");

                return await Context.Movies.AnyAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if movie exists: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get total count of movies.
        /// </summary>
        public async Task<int> GetCountAsync()
        {
            try
            {
                return await Context.Movies.CountAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movie count: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get movies by director name.
        /// </summary>
        public async Task<List<Movie>> GetByDirectorAsync(string directorName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(directorName))
                    throw new ArgumentException("Director name cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .Where(m => m.DirectorName == directorName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movies by director '{directorName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get movies by producer name.
        /// </summary>
        public async Task<List<Movie>> GetByProducerAsync(string producerName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producerName))
                    throw new ArgumentException("Producer name cannot be empty.");

                return await Context.Movies
                    .AsNoTracking()
                    .Where(m => m.ProducerName == producerName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movies by producer '{producerName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get movies with their associated shows.
        /// </summary>
        public async Task<List<Movie>> GetMoviesWithShowsAsync()
        {
            try
            {
                return await Context.Movies
                    .AsNoTracking()
                    .Include(m => m.MovieShows)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movies with shows: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get a specific movie with its associated shows.
        /// </summary>
        public async Task<Movie> GetMovieWithShowsAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Movie ID must be greater than 0.");

                return await Context.Movies
                    .AsNoTracking()
                    .Include(m => m.MovieShows)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving movie with shows (ID {id}): {ex.Message}");
                throw;
            }
        }
    }
}
