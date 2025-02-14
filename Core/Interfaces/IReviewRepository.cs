﻿using CineVerse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVerse.Core.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsAsync(int max = 100, bool includeUser = false, bool includeMovie = false);
        Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId, bool includeUser = false);
        Task<Review> GetReviewByUserIdMovieIdAsync(string userId, int movieId);
    }
}
