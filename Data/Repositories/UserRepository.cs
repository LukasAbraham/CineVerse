﻿using CineVerse.Core.Interfaces;
using CineVerse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVerse.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetPublicUsersAsync()
        {
            return await _context.Set<User>()
                .Where(u => u.ProfileVisibility == ProfileVisibility.Public)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<Movie?>> GetFavouriteMoviesByIds(List<int?> movieIds)
        {
            var movies = await _context.Set<Movie>()
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            var movieDict = movies.ToDictionary(m => m.Id, m => m);

            var result = movieIds.Select(id => id.HasValue && movieDict.ContainsKey(id.Value) ? movieDict[id.Value] : null).ToList();
            return result;
        }
    }
}
