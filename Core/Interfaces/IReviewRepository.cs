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
        Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId);
        Task<Review> GetReviewByUserIdMovieIdAsync(string userId, int movieId);
    }
}
