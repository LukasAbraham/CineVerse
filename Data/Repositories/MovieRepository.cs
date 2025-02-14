﻿using CineVerse.Core.Interfaces;
using CineVerse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CineVerse.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context) { }

        public async Task<int> CountMoviesAsync(
            string? filterBy = null, string? filterValue = null,
            string? sortBy = null, string? sortValue = null)
        {
            IQueryable<Movie> query = _context.Set<Movie>();

            // Filter by something
            if (!string.IsNullOrWhiteSpace(filterBy))
            {
                switch (filterBy.ToLower())
                {
                    case "decade":
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            switch (filterValue.ToLower())
                            {
                                case "all":
                                    break;
                                case "upcoming":
                                    query = query.Where(m => m.ReleaseDate == null);
                                    break;
                                default:
                                    int startYear = int.Parse(filterValue.Substring(0, 4));
                                    int endYear = startYear + 9;
                                    query = query
                                        .Where(m => m.ReleaseDate != null && m.ReleaseDate.Value.Year >= startYear && m.ReleaseDate.Value.Year <= endYear);
                                    break;
                            }
                        }
                        break;
                }
            }

            // Sort by something
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "rating":
                        if (string.IsNullOrWhiteSpace(sortValue)) { break; }
                        switch (sortValue.ToLower())
                        {
                            case "highest first":
                                query = query.OrderByDescending(m => m.VoteAverage);
                                break;
                            case "lowest first":
                                query = query.OrderBy(m => m.VoteAverage);
                                break;
                        }
                        break;
                }
            }

            return await query.CountAsync();
            //return await _context.Set<Movie>().CountAsync();
        }

        public async Task<Movie> GetMovieByTMDBIdAsync(int tmdbId)
        {
            return await _context.Set<Movie>().FirstOrDefaultAsync(m => m.Id == tmdbId);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByPageAsync(int pageNumber, int pageSize,
            string? filterBy = null, string? filterValue = null,
            string? sortBy = null, string? sortValue = null)
        {
            IQueryable<Movie> query = _context.Set<Movie>();

            // Filter by something
            if (!string.IsNullOrWhiteSpace(filterBy))
            {
                switch (filterBy.ToLower())
                {
                    case "decade":
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            switch (filterValue.ToLower())
                            {
                                case "all":
                                    break;
                                case "upcoming":
                                    query = query.Where(m => m.ReleaseDate == null);
                                    break;
                                default:
                                    int startYear = int.Parse(filterValue.Substring(0, 4));
                                    int endYear = startYear + 9;
                                    query = query
                                        .Where(m => m.ReleaseDate != null && m.ReleaseDate.Value.Year >= startYear && m.ReleaseDate.Value.Year <= endYear);
                                    break;
                            }
                        }
                        break;
                }
            }

            // Sort by something
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "rating":
                        if (string.IsNullOrWhiteSpace(sortValue)) { break; }
                        switch (sortValue.ToLower())
                        {
                            case "highest first":
                                query = query.OrderByDescending(m => m.VoteAverage);
                                break;
                            case "lowest first":
                                query = query.OrderBy(m => m.VoteAverage);
                                break;
                        }
                        break;
                }
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<Person>> GetTopCastsByMovieIdAsync(int movieId, int n)
        {
            return await _context.Set<Credit>()
                .Where(c => c.MovieId == movieId && c.Type == "cast")
                .Include(c => c.Person)
                .OrderBy(c => c.Order ?? int.MaxValue)
                .Select(c => c.Person)
                .Distinct()
                .Take(n)
                .ToListAsync();
        }

        public async Task<List<Person>> GetTopCrewsByMovieIdAsync(int movieId, int n)
        {
            return await _context.Set<Credit>()
                .Where(c => c.MovieId == movieId && c.Type == "crew")
                .Include(c => c.Person)
                .Select(c => c.Person)
                .Distinct()
                .Take(n)
                .ToListAsync();
        }

        public async Task<Person> GetDirectorByMovieIdAsync(int movieId)
        {
            return await _context.Set<Credit>()
                .Where(c => c.MovieId == movieId && c.Job == "Director")
                .Include(c => c.Person)
                .Select(c => c.Person)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Person>> GetDirectorsByMovieIdAsync(int movieId)
        {
            return await _context.Set<Credit>()
                .Where(c => c.MovieId == movieId && c.Job == "Director")
                .Include(c => c.Person)
                .Select(c => c.Person)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm, int maxItems = 100)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<Movie>();
            }

            IQueryable<Movie> query = _context.Set<Movie>();

            searchTerm = searchTerm.ToLower();
            query = query.Where(m => m.Title.ToLower().Contains(searchTerm)
                || m.Credits.Any(c => c.Person.Name.ToLower() == searchTerm && c.Job == "Director"));

            return await query.Take(maxItems).ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByIdsAsync(List<int> movieIds)
        {
            return await _context.Set<Movie>()
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();
        }
    }
}
