﻿using CineVerse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineVerse.Core.Interfaces
{
    public interface IPostVoteRepository : IRepository<PostVote>
    {
        Task<PostVote> GetPostVoteByPostIdUserIdAsync(string postId, string userId);
    }
}
